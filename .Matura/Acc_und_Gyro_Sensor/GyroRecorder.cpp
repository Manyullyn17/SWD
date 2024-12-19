
#include "mbed.h"
#include "MPU6050Ts.h"
#include "Serial_HL4.h"

SerialHL4 pc(USBTX, USBRX);
SvProtocol ua0(&pc);

class ImuChan3 {
	public:
		ImuChan3(int* aRawVal);
		int GetVal(int i)
			{ return rawVal[i] - offset[i]; }
	public:
		int* rawVal;
		int offset[3];
};

MPU6050As mpu(D4, D5);
ImuChan3 imc3(mpu.gy);

void SetPriorities();
void CommandHandler();
void MpuError();
void CalcGyroOffset();

int main(void)
{
	SetPriorities();
	pc.format(8,SerialHL4::None,1); pc.baud(500000); pc.Init();
	ua0.SvMessage("GyroRecorder_1"); 

	mpu.initialize();
	if( !mpu.testConnection() ) 
		MpuError();
	// wait_ms(100); mpu.InitISR();
	ua0.SvMessage("MPU OK");

	Timer stw; stw.start();
	while(1) {
		CommandHandler();
		if( stw.read_us()>2000 ) { // 500Hz
			stw.reset();
			if( ua0.acqON ) {
				mpu.getGyroBL();
				ua0.WriteSvI16(1, imc3.GetVal(0));
				ua0.WriteSvI16(2, imc3.GetVal(1));
				ua0.WriteSvI16(3, imc3.GetVal(2));
				pc.Flush();
			}
		}
  }
  return 1;
}

void CommandHandler()
{
	uint8_t cmd;
	if( !pc.IsDataAvail() )
		return;
	cmd = ua0.GetCommand();
	
	if( cmd==2 ) {
		ua0.SvMessage("CalcOffset"); 
		CalcGyroOffset();
		ua0.SvMessage("CalcOffset Fin");
	}
}

ImuChan3::ImuChan3(int aRawVal[])
{
	rawVal=aRawVal;
	for(int i=0; i<3; i++) offset[i]=0; 
}

void CalcGyroOffset()
{
	int sum[3], i;
	for(i=0; i<3; i++) sum[i]=0;
	for(int j=1; j<=500; j++) {
		mpu.getGyroBL();
		for(i=0; i<3; i++)
			sum[i] += mpu.gy[i];
		wait_ms(1);
	}
	for(i=0; i<3; i++)
		imc3.offset[i]=sum[i]/500;
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



