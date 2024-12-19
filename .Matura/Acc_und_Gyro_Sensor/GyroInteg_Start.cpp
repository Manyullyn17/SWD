
#include "mbed.h"
#include "MPU6050Ts.h"
#include "Serial_HL.h"
#include "Tp1Ord.h"
#include "ComplFilt_SwDev.h"

SerialBLK pc(USBTX, USBRX);
SvProtocol ua0(&pc);

MPU6050As mpu(D4, D5);

void SetPriorities();
void CommandHandler();
void MpuError();

Timer stw2; int cycTime;

int gyY, accX;

ComplFilt cmp;

int main(void)
{
	stw2.start();
	pc.format(8,SerialBLK::None,1); pc.baud(500000); // pc.Init();
	ua0.SvMessage("Gyro_Integ_1"); 
	mpu.initialize();
	if( !mpu.testConnection() ) 
		MpuError();
	SetPriorities();
	ua0.SvMessage("MPU OK");
	
	Timer stw; stw.start();
	while(1) {
		CommandHandler();
		if( stw.read_ms()>10 ) { // 100Hz
			stw.reset();
			if( ua0.acqON ) {
				ua0.WriteSvI16(1, gyY);
				ua0.WriteSvI16(2, accX);
				ua0.WriteSvI16(3, cycTime);
				pc.Flush();
			}
		}
  }
  return 1;
}

void SysTick_ISR() // 1kHZ höchste Priorität
{
	cycTime=stw2.read_us(); stw2.reset();
	gyY=-mpu.getGyroY(); accX=mpu.getAccelX();
	cmp.UpdateRawVals(accX, gyY);
	cmp.CalcFilter();
}


void CommandHandler()
{
	uint8_t cmd;
	if( !pc.IsDataAvail() )
		return;
	cmd = ua0.GetCommand();
	if( cmd==2 ) {
		cmp.Reset(); // Integ resetten
		ua0.SvMessage("Reset");
	}
	if( cmd==3 ) {
		ua0.SvMessage("CalcOffset");
		// CalcOffset();
		cmp.Reset(); // Integ resetten
		ua0.SvMessage("CalcOffset done");
	}
}

void CalcOffset()
{
	// i=1 500
	// cmp.gy.offset
	int sum = 0;
	for(int i=1; i<=500; i++)
	{
		sum += gyY;
		wait(0.01);
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



