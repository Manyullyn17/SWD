

class BtnEventM0 {
	public:
		int16_t pressed;
		
		BtnEventM0(PinName pin) : _isr(pin)
			{ pressed=0; }

		// Ist eine steigende Flanke aufgetreten ?
		int CheckFlag()
		{
			if( pressed )
				{ pressed=0; return 1; }
			return 0;
		}
		
		// 1..Button is pressed  else 0
		int CheckButton()
			{ return !_isr.read(); }
		
		void Init()
			{ _isr.fall(this, &BtnEventM0::FallingISR); }

		void FallingISR() 
		{
			// wait_ms(5);
			if( !_isr.read() )
				pressed = 1;
		}
	protected:
		InterruptIn _isr;
};


/* 
class BtnEventM02 : public BtnEventM0 {
	public:
		BtnEventM02(PinName pin) : BtnEventM0(pin)
			{ _tm.stop(); _tm.reset(); _state=1; }

		void Init()
			{ _isr.rise(this, &BtnEventM02::RisingISR); }

		void RisingISR()
		{
			if( !_isr.read() )
				return;
			pressed = 1;
			_tm.start();
			_state = 2;
		}

		void CheckButton()
		{
			if( _state==1 )
				return;
			if( _state==2 ) {
				if( !_isr.read() ) {
					_state = 1;
					return;
				}
				if( _tm.read_ms()>500 ) {
					_tm.reset();
					_state = 3;
					pressed = 1;
				}
			}
			else if( _state==3 ) {
				if( !_isr.read() ) {
					_state = 1;
					return;
				}
				if( _tm.read_ms()>100 ) {
					_tm.reset();
					_state = 3;
					pressed = 1;
				}
			}
		}
	private:
		int16_t _state;
		Timer _tm;
}; */

#ifndef ANALOG_IN_HL
#define ANALOG_IN_HL

class AnalogInHL : public AnalogIn {
	public:
		AnalogInHL(PinName pin) : AnalogIn(pin) { }
		int Read()
			{ return read_u16()>>6; }
};

#endif

