
#include "Filters2.h"
#include "math.h"

class ImuChan2 {
	public:
		ImuChan2()
			{ rawVal=offset=0; }
		int16_t GetVal()
			{ return rawVal - offset; }
	public:
		int16_t rawVal;
		int16_t offset;
};

class BalSensBase {
	protected:
		static const float DT_SENS = 1E-3;
	public:
		BalSensBase() { }
		void UpdateRawVals(int aAcc, int aGyro);
	public:
		ImuChan2 acc;
		ImuChan2 gy;
};

void BalSensBase::UpdateRawVals(int aAcc, int aGyro)
{
	acc.rawVal=aAcc; gy.rawVal=aGyro; 
}


class ComplFilt : public BalSensBase {
		static const int ACC_MAX = 2050; // -2000..2105
		static const float GY_ANGLE_FACT = (2000.0/32767.0)*10.0;
		static const float ALPHA = 0.001f; // 0.02
		static const float BETA = 1.0f-ALPHA;
	public:
		ComplFilt() : BalSensBase() { Reset(); }
		
		void Reset() 
			{ _gySum=0; _complAngle=0; }
		
		float GetOmega() 
			{ return (float)gy.GetVal()*GY_ANGLE_FACT; }
		
		float GetAccAngle();
		
		float GetIntegAngle()
			{ return (float)_gySum*GY_ANGLE_FACT*DT_SENS; }
		
		float GetComplAngle()
			{ return _complAngle; }
		
		void CalcFilter();
	private:
		int _gySum;
		float _complAngle;
};

void ComplFilt::CalcFilter()
{
	_gySum += gy.GetVal();
}

float ComplFilt::GetAccAngle()
{
	int val = acc.GetVal();
	if( val>ACC_MAX ) val=ACC_MAX;
	if( val<-ACC_MAX ) val=-ACC_MAX;
	return 10.0f*RAD_GRAD*asin((float)val/(float)ACC_MAX);
}
















