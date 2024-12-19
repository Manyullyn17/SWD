
#include "mbed.h"
#include "MPU6050Ts.h"
#include "Serial_HL4.h"
#include "Tp1Ord.h"
#include "ComplFilt.h"

SerialHL4 pc(USBTX, USBRX);
SvProtocol ua0(&pc);

MPU6050As mpu(D4, D5);
ComplFilt cf;

void SetPriorities();
void CommandHandler();
void MpuError();

Tp1OrdF tp;
Timer stw2; int cycTime;

int main(void)
{
	stw2.start();
	pc.format(8,SerialHL4::None,1); pc.baud(500000); pc.Init();
	ua0.SvMessage("ComplFiltMain_3"); 
	mpu.initialize();
	if( !mpu.testConnection() ) 
		MpuError();
	// wait_ms(100); mpu.InitISR();
	SetPriorities();
	ua0.SvMessage("MPU OK");
	
	Timer stw; stw.start();
	while(1) {
		CommandHandler();
		if( stw.read_ms()>10 ) { 
			stw.reset();
			if( ua0.acqON ) {
				ua0.WriteSvI16(1, cf.GetOmega());
				ua0.WriteSvI16(2, cf.GetAccAngle());
				ua0.WriteSvI16(3, cf.GetIntegAngle());
				ua0.WriteSvI16(4, cf.GetComplAngle());
				// ua0.WriteSvI16(4, cycTime);
				pc.Flush();
			}
		}
  }
  return 1;
}

void SysTick_ISR()
{
	cycTime=stw2.read_us(); stw2.reset();
	if( cf.calibFlag )
		return;
	mpu.getAccelBL();
	
	cf.UpdateRawVals(mpu.getAccelX(), -mpu.getGyroY());
	cf.CalcFilter();
}


void CalcAccOffset()
{
	cf.calibFlag=1; int sum=0; cf.acc.offset=0;
	for(int i=1; i<=300; i++) {
		cf.acc.val=mpu.getAccelX();
		cf.acc.CalcFilt();
		sum += cf.acc.GetFilt();
		wait_us(1000);
	}
	cf.acc.offset= sum/300; cf.calibFlag=0;
}

void CalcGyroOffset()
{
	cf.calibFlag=1; int sum=0; cf.gy.offset=0;
	for(int i=1; i<=300; i++) {
		cf.gy.val = -mpu.getGyroY();
		cf.gy.CalcFilt();
		sum += cf.gy.GetFilt();
		wait_us(1000);
	}
	cf.gy.offset= sum/300; cf.calibFlag=0;
}

void CommandHandler()
{
	uint8_t cmd;
	if( !pc.IsDataAvail() )
		return;
	cmd = ua0.GetCommand();
	if( cmd==2 ) {
		cf.Reset();
		ua0.SvMessage("Reset");
	}
	if( cmd==3 ) {
		ua0.SvMessage("CalcAccOffset");
		CalcAccOffset(); CalcGyroOffset();
		cf.Reset();
		ua0.SvMessage("CalcAccOffset done");
	}
}


void MpuError()
{
	ua0.SvMessage("MPU FAIL!!");
	while(1);
}

void SetPriorities()
{
	HAL_NVIC_DisableIRQ(SysTick_IRQn);
	HAL_NVIC_DisableIRQ(EXTI15_10_IRQn);
	
	HAL_SYSTICK_Config(HAL_RCC_GetHCLKFreq()/1000); 
	NVIC_SetVector(SysTick_IRQn, (uint32_t)SysTick_ISR);
	
	HAL_NVIC_SetPriority(EXTI15_10_IRQn, 2, 0);
	HAL_NVIC_SetPriority(SysTick_IRQn, 5, 0);
	
	HAL_NVIC_EnableIRQ(SysTick_IRQn);
	HAL_NVIC_EnableIRQ(EXTI15_10_IRQn);

	HAL_NVIC_SetPriority(USART1_IRQn, 4, 0);
	HAL_NVIC_SetPriority(USART2_IRQn, 4, 0);
}



