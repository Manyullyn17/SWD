#include "mbed.h"
#include "Serial_HL.h"
#include "Bertl16.h"
#include "PeriPhWrapper.h"
#include "MotionControl.h"
#include "SpeedPID.h"
#include "MotionControl2.h"
#include "MotorPins.h"
#include "LineSensor.h"
 
SerialBLK pc(USBTX, USBRX);
SvProtocol ua0(&pc);
void CommandHandler();

int dispMode = 1;

int main(void)
{
	boardPow=3; wait(0.2);
	pc.format(8,SerialBLK::None,1); pc.baud(115200);
	AllLedsOff();
	
	ua0.SvMessage("LineCalTest2_3");
	Timer stw; stw.start();
  while(1) {
		CommandHandler();
		if( stw.read_ms()>10 ) {
			stw.reset();
      if( ua0.acqON ) {
        if( dispMode==1 ) {
          ls.CalcFilt();
          ls.DispRawVals(&ua0);
        }
				else if( dispMode==2 ) {
          ls.OneCalStep();
          ls.DispRawVals(&ua0);
        }
        else { // 3
          ls.DispCalVals(&ua0);
					ua0.WriteSvI16(5,ls.GetPos2());
          ua0.WriteSvI16(6,ls.posDiff);
				}
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
    dispMode = ua0.ReadI16();
		if( dispMode==1 )
			ua0.SvMessage("Raw Vals");
		else if( dispMode==2 )
			{ ls.InitCalAll(); ua0.SvMessage("Calibartion"); }
		else // 3
			ua0.SvMessage("Cal Vals");
	}
  if( cmd==3 ) {
		ls.DispMinMax(&ua0);
	}
}



















