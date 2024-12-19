
#include "mbed.h"
#include "BtnEventStm.h"

Serial pc(USBTX, USBRX);

//        1  2  4  8
BusOut lb(D2,D3,D6,D9,  D11,D12,A6,D13);
BtnEventM0 T1(A2);

//         R  G   B
BusOut rgb(D1,D0, D10);

const int ST_ROT = 1;
const int ST_GELB = 2;
const int ST_GRUEN = 3;

class Ampel {
public:
	void Init();
	void Rot();
	void Gelb();
	void Gruen();
public:
	void RotAction();
	void GelbAction();
	void GruenAction();
public:
	int state;
  Timer t1; // ampelphasen unschalten
  Timer t2; // blinken
  Timer t3; // anzeige updaten
};

Ampel amp;

void main()
{
	T1.Init();
	pc.format(8, Serial::None, 1);
	pc.baud(500000);
	rgb=0; amp.Init();
	
	while(1)
	{
		if( amp.state==ST_ROT )
			amp.Rot();
		if( amp.state==ST_GELB )
			amp.Gelb(); 
		if( amp.state==ST_GRUEN )
			amp.Gruen(); 
	}
}

void Ampel::Init()
{
	state=ST_ROT;
	t1.start(); t2.start(); t3.start();
}

void Ampel::Rot()
{
	pc.printf("ROT\n");
	t1.reset();
	while(1)
	{
		if( t1.read_ms()>3000 )
			{ state=ST_GELB; return; }
		RotAction();
	}
}

void Ampel::RotAction()
{
	// rot blinken
	if( t2.read_ms()>100 ) {
		t2.reset();
		if( rgb==0 )
			rgb=1;
		else
			rgb=0;
	}
	// Zeit mit 10Hz zur anzeige senden
	if( t3.read_ms()>100 ) {
		t3.reset(); // 2..2te Zeile am simulierten LCD-Display
		pc.printf("2 %d\n", t1.read_ms()/100); // Zeitanzeige auf 1/10Sec gneau
	}
}

void Ampel::Gelb()
{
	pc.printf("GELB\n");
	t1.reset();
	while(1)
	{
		if( t1.read_ms()>4000 )
			{ state=ST_GRUEN; return; }
		if( T1.CheckFlag() )
			{ state=ST_ROT; return; }
		GelbAction();
	}
}

void Ampel::GelbAction()
{
	// rot blinken
	if( t2.read_ms()>100 ) {
		t2.reset();
		if( rgb==0 )
			rgb=3;
		else
			rgb=0;
	}
	// Zeit mit 10Hz zur anzeige senden
	if( t3.read_ms()>100 ) {
		t3.reset(); // 2..2te Zeile am simulierten LCD-Display
		pc.printf("2 %d\n", t1.read_ms()/100); // Zeitanzeige auf 1/10Sec gneau
	}
}


void Ampel::Gruen()
{
	pc.printf("GRUEN\n");
	t1.reset();
	while(1)
	{
		if( t1.read_ms()>5000 )
			{ state=ST_ROT; return; }
		if( T1.CheckFlag() )
			{ state=ST_ROT; return; }
		GruenAction();
	}
}

void Ampel::GruenAction()
{
	// rot blinken
	if( t2.read_ms()>100 ) {
		t2.reset();
		if( rgb==0 )
			rgb=2;
		else
			rgb=0;
	}
	// Zeit mit 10Hz zur anzeige senden
	if( t3.read_ms()>100 ) {
		t3.reset(); // 2..2te Zeile am simulierten LCD-Display
		pc.printf("2 %d\n", t1.read_ms()/100); // Zeitanzeige auf 1/10Sec gneau
	}
}














