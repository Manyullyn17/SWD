
#ifndef SineGen_h
#define SineGen_h

#include "math.h"

const float M_PI = (float)3.1415926535897932384626433832795;


class Complex {
  public:
    float re, im;
  public:
    Complex()
      { re=0; im=0; }
    
    void SetPolar(float aR, float aPhi)
      { re = aR*cos(aPhi); im = aR*sin(aPhi); }

    Complex Mult(Complex aB)
    {
      Complex prod;
      prod.re = re*aB.re - im*aB.im;
      prod.im = im*aB.re + re*aB.im;
      return prod;
    }
};


class SineGen {
  public:
    Complex _inc;
  public:
    Complex val;
  public:
    SineGen()
			{ Init(); }
	
		void Init()
			{ Reset(); SetPointsPerPeriod(50.0); }
    
    void Reset()
      { val.SetPolar(1.0,0.0); }
    
    void SetPointsPerPeriod(float aPoints)
      { _inc.SetPolar(1.0, (2*M_PI)/aPoints); }

    void SetFrequ(float aFrequ)
      { SetPointsPerPeriod(1.0f/aFrequ); }

    void CalcOneStep()
      { val = val.Mult(_inc); }
};


class RectHarm {
  public:
    float val;
  private:
    SineGen fg1, fg3, fg5;
  public:
    RectHarm()
      { SetFrequ(0.005); }
    
    void SetFrequ(float aFrequ)
      { fg1.SetFrequ(aFrequ); fg3.SetFrequ(3.0f*aFrequ); fg5.SetFrequ(5.0f*aFrequ); }

    void CalcOneStep()
    {
      fg1.CalcOneStep(); fg3.CalcOneStep(); fg5.CalcOneStep();
      val = fg1.val.im + (1.0/3.0)*fg3.val.im + (1.0/5.0)*fg5.val.im;
    }
};


#endif

