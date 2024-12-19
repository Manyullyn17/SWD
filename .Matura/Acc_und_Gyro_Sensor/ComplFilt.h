
#include "Filters2.h"
#include "math.h"

class ImuChan2 {
	public:
		ImuChan2()
			{ val=offset=sf=0; }
		int16_t GetVal()
			{ return val - offset; }
		int16_t GetFilt()
			{ return (filt.yn>>sf) - offset; }
		void CalcFilt()
			{ filt.CalcOneStep(val<<sf); }
		void CalcOffset();
	public:
		Tp2Ord filt;
		int16_t val;
		int16_t offset;
		int16_t sf;
};

class BalSensBase {
	protected:
		static const float DT_SENS = 1E-3;
	public:
		BalSensBase();
		void UpdateRawVals(int aAcc, int aGyro);
		void CalcGyOffset();
		void CalcAccOffset();
	public:
		ImuChan2 acc;
		ImuChan2 gy;
		int16_t calibFlag;
};

BalSensBase::BalSensBase()
{
	calibFlag=0; gy.offset=0; acc.offset=0; 
	acc.sf=18; gy.sf=17;
	acc.filt.Init(TP_COE_p010);
	gy.filt.Init(TP_COE_p05);
}

void BalSensBase::UpdateRawVals(int aAcc, int aGyro)
{
	acc.val=aAcc; acc.CalcFilt();  
	gy.val=aGyro; gy.CalcFilt();
}


class ComplFilt : public BalSensBase {
		static const int ACC_MAX = 2050; // -2000..2105
		static const float GY_ANGLE_FACT = (2000.0/32767.0)*10.0;
		static const float ALPHA = 0.001f; // 0.02
		static const float BETA = 1.0f-ALPHA;
	  static const float BETA2 = 1.0f-0.00001f;
	public:
		ComplFilt() : BalSensBase() { Reset(); }
		void Reset() { _gySum=0; _complAngle=0; _TPAngle=0; }
		float GetOmega() { return (float)gy.GetFilt()*GY_ANGLE_FACT; }
		float GetAccAngle();
		float GetSmalAccAngle();
		float GetIntegAngle()
			{ return (float)_gySum*GY_ANGLE_FACT*DT_SENS; }
		float GetComplAngle()
			{ return _complAngle; }
		float GetTPAngle()
			{ return _TPAngle; }
		void CalcFilter();
	private:
		int _gySum;
		float _complAngle;
		float _TPAngle;
};

void ComplFilt::CalcFilter()
{
	_gySum += gy.GetFilt();
	float omega = GY_ANGLE_FACT*DT_SENS*(float)gy.GetFilt();
	// _gySum += omega;
	_complAngle = BETA*(_complAngle + omega) + ALPHA*GetAccAngle();
	// _TPAngle = _TPAngle*BETA + omega*ALPHA;
	_TPAngle =  BETA*(_TPAngle + omega);
}

float ComplFilt::GetAccAngle()
{
	int val = acc.GetFilt();
	if( val>ACC_MAX ) val=ACC_MAX;
	if( val<-ACC_MAX ) val=-ACC_MAX;
	return 10.0f*RAD_GRAD*asin((float)val/(float)ACC_MAX);
}

float ComplFilt::GetSmalAccAngle()
{
	int val = acc.GetFilt();
	if( val>ACC_MAX ) val=ACC_MAX;
	if( val<-ACC_MAX ) val=-ACC_MAX;
	return 10.0f*RAD_GRAD*((float)val/(float)ACC_MAX);
}


// uses Gyro only DriftCorrection towards 0°
class BalSensSimple : public  BalSensBase {
		static const float ALPHA = 0.9f; // 0.999
		static const float BETA = 1.0f - ALPHA;
	public:
		BalSensSimple() : BalSensBase() 
			{ Reset(); }

		void Reset()
			{ _dynOffset=_gySum=0; }
		
		void CalcFilter()
		{
			_dynOffset = _dynOffset*ALPHA + (float)gy.GetVal()*BETA;
			_gySum += GetOmega();
		}

		float GetOmega() 
			{ return (float)gy.GetVal()-_dynOffset; }

		float GetPhi()
			{ return _gySum*3.0f*DT_SENS; }
	
	private:
		float _dynOffset;
		float _gySum;
};


void BalSensBase::CalcGyOffset()
{
	calibFlag = 1;
	int sum=0;
	gy.offset=0;
	for(int i=1; i<=300; i++) {
		// gy.val = mpu.getRotationX();
		// gy.val = -mpu.getRotationY(); // BalBot-Schuster
		gy.CalcFilt();
		sum += gy.GetFilt();
		wait_us(1000);
	}
	gy.offset = sum/300;
	calibFlag = 0;
}

void BalSensBase::CalcAccOffset()
{
	calibFlag = 1;
	int sum=0;
	acc.offset=0;
	for(int i=1; i<=300; i++) {
		// acc.val = mpu.getAccelerationY();
		// acc.val =  mpu.getAccelerationX(); // BalBot-Schuster
		acc.CalcFilt();
		sum += acc.GetFilt();
		wait_us(1000);
	}
	acc.offset = sum/300;
	calibFlag = 0;
}






