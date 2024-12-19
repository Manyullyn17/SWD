
#include "mbed.h"
#include "Serial_HL.h"
#include "FuncGenAll.h"
#include "SineGenLsg.h"
#include "Tp1Ord.h"

SerialBLK pc(USBTX, USBRX);
SvProtocol ua0(&pc);

void CommandHandler();
void ExecSignalChain();

SignedRampGen fg1; RectGen fg2;
TriangleGen fg3; SineGen fg4;
Tp1Ord tp; // ein TP-Filter anlegen

// AnalogOut dac(PA_5);

int swt=1; float v1=0; float ampl=1.0;

const float DAC_FREQU = 10E3; // 10khz

int main(void)
{
	pc.format(8,SerialBLK::None,1);
	pc.baud(500000); fg4.Init();
	
	Ticker tc; tc.attach(ExecSignalChain,1.0/DAC_FREQU);
	
	ua0.SvMessage("FuncGenAll_1"); 
	
	Timer stw; stw.start();
	while(1) {
		CommandHandler();
		if( stw.read_ms()>10 ) { // 100Hz
			stw.reset(); 
			// ExecSignalChain();
			if( ua0.acqON ) {
				ua0.WriteSV(1, v1); // vor dem Filter
				ua0.WriteSV(2, tp.y); // das gefilterte Signal
			}
		}
	}
	return 1;
}

void ExecSignalChain()
{
	if( swt==1 )
		{ fg1.CalcOneStep(); v1=fg1.val; }
	if( swt==2 )
		{ fg2.CalcOneStep(); v1=fg2.val; }
	if( swt==3 )
		{ fg3.CalcOneStep(); v1=fg3.val; }
	if( swt==4 )
		{ fg4.CalcOneStep(); v1=fg4.val.im; } 
	v1 *= ampl;
	tp.CalcOneStep(v1);
	// dac.write(v1*0.5 + 0.5);
}

void CommandHandler()
{
	uint8_t cmd;
	if( !pc.IsDataAvail() )
			return;
	cmd = ua0.GetCommand();
	
	if( cmd==2 ) { // Frequenz verstellen
		float frequ=ua0.ReadF();
	  fg1.SetFrequ(frequ); fg2.SetFrequ(frequ);
		fg3.SetFrequ(frequ); fg4.SetFrequ(frequ);
		ua0.SvMessage("Set Frequ.");
		ua0.SvPrintf("%1.3f  %1.3f", fg4._inc.re, fg4._inc.im);
	}
	if( cmd==3 ) { // Amplitude verstellen
	  ampl=ua0.ReadF();
		ua0.SvMessage("Set Ampl.");
	}
	if( cmd==4 ) { 
		swt=ua0.ReadI16();
		ua0.SvMessage("Swt Wave");
	}
	if( cmd==5 ) {
		tp.SetAlpha(ua0.ReadF());
		ua0.SvMessage("SetAlpha");
	}
}















