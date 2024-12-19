
#include "mbed.h"
#include "BtnEventStm.h"

BusOut lb(D2,D3,D6,D9,D11,D12,A6,D13);

BtnEventM0 T1(A2);
BtnEventM0 T2(A1);

class Fahrradleuchte {   // Deklaration
	public:
		void Init()
			{ state=1; t1.start(); }
		void State1();
		void State2();
		void State3();
	public:
		void State1Action();
		void State2Action();
		void State3Action();
	public:
		int state;
		Timer t1;
}; 

// eine Fahrradleuchte erzeugen
Fahrradleuchte fl;

int main()
{
	T1.Init(); T2.Init();
	fl.Init();
	
	while(1)
	{
		if( fl.state==1 )
			fl.State1();
		if( fl.state==2 )
			fl.State2();
		if( fl.state==3 )
			fl.State3();
	}
	
	return 0;
}

void Fahrradleuchte::State1()
{
	t1.reset();
	while(1) {
		// Btn's abfragen und möglicherweise Zustand ändern
		if( T1.CheckFlag() )
			{ state=2; return; }
		if( T2.CheckFlag() )
			{ state=3; return; }
		State1Action();
	}
}

void Fahrradleuchte::State1Action()
{
	if( t1.read_ms()<500 )
		return; // Timer noch nicht abgelaufen
	t1.reset(); // es gibt was zu tun ( Blinken )
	if( lb==0 )
		lb = 0xFF;
	else
		lb = 0;
}


void Fahrradleuchte::State2()
{
	t1.reset();
	lb = 1;
	while(1) {
		// Btn's abfragen und möglicherweise Zustand ändern
		if( T1.CheckFlag() )
			{ state=3; return; }
		if( T2.CheckFlag() )
			{ state=1; return; }
		State2Action();
	}
}

void Fahrradleuchte::State2Action()
{
	if( t1.read_ms()<200 )
		return; // Timer noch nicht abgelaufen
	t1.reset(); // es gibt was zu tun ( Blinken )
	if( lb!=0 ) // schieben
		lb = lb << 1;
	else // neu initialisieren
		lb = 1;
}



void Fahrradleuchte::State3()
{
	t1.reset();
	lb = 128; // 2^7
	while(1) {
		// Btn's abfragen und möglicherweise Zustand ändern
		if( T1.CheckFlag() )
			{ state=1; return; }
		if( T2.CheckFlag() )
			{ state=2; return; }
		State3Action();
	}
}

void Fahrradleuchte::State3Action()
{
	if( t1.read_ms()<1000 )
		return; // Timer noch nicht abgelaufen
	t1.reset(); // es gibt was zu tun ( Blinken )
	if( lb!=0 ) // schieben
		lb = lb >> 1;
	else // neu initialisieren
		lb = 128;
}



























