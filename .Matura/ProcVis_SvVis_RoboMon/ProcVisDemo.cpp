
#include "mbed.h"
#include "Serial_HL.h"
 
SerialBLK pc(USBTX, USBRX);
SvProtocol ua0(&pc);

void CommandHandler();

int main(void)
{
	pc.format(8,SerialBLK::None,1); pc.baud(500000); // 115200
	ua0.SvMessage("ProcVisDemo1"); // Meldung zum PC senden
	
	int16_t sv1=0, sv2=100; float sv3=0;
	Timer stw; stw.start();
  while(1)
  {
    CommandHandler();
    if( (stw.read_ms()>100) ) // 10Hz
    { // dieser Teil wird mit 10Hz aufgerufen
      stw.reset();
      sv1++; sv2++; sv3 += 0.1;
      if( ua0.acqON ) {
        // nur wenn vom PC aus das Senden eingeschaltet wurde
        // wird auch etwas gesendet
        ua0.WriteSvI16(1, sv1); // WriteSvI16() für int
        ua0.WriteSvI16(2, sv2);
				ua0.WriteSV(3, sv3); // WriteSV() für float
      }
    }
  }
  return 1;
}

void CommandHandler()
{
  uint8_t cmd;
  int16_t idata1, idata2;
  
  // Fragen ob überhaupt etwas im RX-Reg steht
  if( !pc.IsDataAvail() )
    return;
  
  // wenn etwas im RX-Reg steht
	// Kommando lesen
	cmd = ua0.GetCommand();

  if( cmd==2 )
	{
		// cmd2 hat 2 int16 Parameter
    idata1 = ua0.ReadI16(); idata2 = ua0.ReadI16();
    // für die Analyse den Wert einfach nur zum PC zurücksenden
    ua0.SvPrintf("Command2 %d %d", idata1, idata2);
  }
}
















