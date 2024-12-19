
#include "mbed.h"
#include "MPU6050Ts.h"
#include "Serial_HL4.h"
#include "Tp1Ord.h"

SerialHL4 pc(USBTX, USBRX);
SvProtocol ua0(&pc);

// D4, D5 
MPU6050As mpu(D4, D5); // PB_7, PB_6
int16_t gx, gy, gz;

Tp1OrdF tpx, tpy, tpz;

void SetPriorities();
void CommandHandler();
void MpuError();
void DispAcc();
void DispGyro();

int main(void)
{
	SetPriorities();
	pc.format(8,SerialHL4::None,1); pc.baud(500000); pc.Init();
	ua0.SvMessage("MPU_TS_Test_7"); 

	mpu.initialize();
	if( !mpu.testConnection() ) 
		MpuError();
	// wait_ms(100); mpu.InitISR();
	ua0.SvMessage("MPU OK");

	Timer stw; stw.start();
	while(1) {
		CommandHandler();
		if( stw.read_ms()>10 ) { 
			stw.reset();
			if( ua0.acqON ) {
				mpu.getAccelBL(); // werte über I2C holen
				DispAcc();
				pc.Flush(); // Flush nicht!!
			}
		}
  }
  return 1;
}

void DispGyro()
{
	ua0.WriteSvI16(1, mpu.gy[0]); 
	ua0.WriteSvI16(2, mpu.gy[1]); 
	ua0.WriteSvI16(3, mpu.gy[2]);
}

void DispAcc()
{
	tpx.CalcOneStep(mpu.acc[0]);
	tpy.CalcOneStep(mpu.acc[1]);
	tpz.CalcOneStep(mpu.acc[2]);
	ua0.WriteSvI16(1, tpx.y);
	ua0.WriteSvI16(2, tpy.y);
	ua0.WriteSvI16(3, tpz.y);  	
}

void CommandHandler()
{
	uint8_t cmd;
	if( !pc.IsDataAvail() )
		return;
	cmd = ua0.GetCommand();

	if( cmd==2 ) {
		int rg=ua0.ReadI16();
		mpu.setGyroRange(rg); // 0,1,2,3
		ua0.SvPrintf("Set Gy Range %d", rg);
	}
	if( cmd==3 )
	{
		float freq = ua0.ReadF();
		tpx.SetAlpha(freq);
		tpy.SetAlpha(freq);
		tpz.SetAlpha(freq);
		ua0.SvMessage("SetAlpha");
	}
	
	if( cmd==4 )
	{
		int v1, v2;
		v1=ua0.ReadI16(); v2=ua0.ReadI16();
		ua0.SvPrintf("TestCmd %d %d",v1,v2);
	}
		
}

void MpuError()
{
	ua0.SvMessage("MPU FAIL!!");
	while(1);
}

void SetPriorities()
{
	// HAL_NVIC_SetPriority(EXTI15_10_IRQn, 3, 0);
	HAL_NVIC_SetPriority(USART1_IRQn, 7, 0);
	HAL_NVIC_SetPriority(USART2_IRQn, 7, 0);
}



