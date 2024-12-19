

class LineChannel : public AnalogInHL2 {
    static const float ALPHA = 0.07; // 0.07
    static const float BETHA = 1 - ALPHA;
	public:
		LineChannel(PinName pin) : AnalogInHL2(pin) 
			{ InitCal(); }

		LineChannel(PinName pin, int aMin, int aMax) : AnalogInHL2(pin) 
			{ _min=aMin; _max=aMax; CalcCalibration(); }
		
		void InitCal()
			{ _min=32000; _max=0; y=400; }
		
		void CalcCalibration();

    void CalcFilt()
      { y = y*BETHA + (float)Read()*ALPHA; }
    
    float CalVal()
			{ y=((float)(Read()-_min))*_k; return y; }
  public:
    float y;
	public:
		int16_t _min, _max;
		float _k;
};

void LineChannel::CalcCalibration()
{
  CalcFilt();
	if( ((int16_t)y) < _min )
		_min = y;
	if( ((int16_t)y) > _max )
		_max = y;
	if( (_max-_min)==0 )
		return;
	_k = 3000.0/(float)(_max-_min);
}

LineChannel ls1(P1_9, 226, 3805);
LineChannel ls2(P0_16, 240, 3635);
LineChannel ls3(P1_3, 234, 3464); 
LineChannel ls4(P0_23, 206, 3446);
LineChannel* ary[] = { &ls1, &ls2, &ls3, &ls4 };

class LineSensor {
		static const int N_SENS = 4;
  public:
    int GetPos();
    int GetPos2();
    void InitCalAll();
    void OneCalStep();
    void CalcFilt();
    void DispRawVals(SvProtocol* aSvp);
    void DispCalVals(SvProtocol* aSvp);
		void DispMinMax(SvProtocol* aSvp);
  public:
    int pos;
    int posDiff;
};

LineSensor ls;

int LineSensor::GetPos()
{
  int val = (int)ls1.CalVal() + 2*(int)ls2.CalVal() + 3*(int)ls3.CalVal() +
            4*(int)ls4.CalVal();
  return val;
}

int z1, z2;

int LineSensor::GetPos2()
{
  int sum=0, weight=0, i;
  for(i=0; i<N_SENS; i++) 
    ary[i]->CalVal();

  posDiff = 0;
	if( (ls1.y<1000) && (ls2.y<150) && (ls3.y<150) && (ls4.y<1000) )
    return pos; 
  
  for(i=0; i<N_SENS; i++)
    sum += ary[i]->y;
  for(i=0; i<N_SENS; i++)
		weight += 200*(i+1)*ary[i]->y;
  
  pos = weight/sum;
  posDiff = pos - z2;
  z2=z1; z1=pos;
  return pos;
}


void LineSensor::InitCalAll()
{
  ls1.InitCal(); ls2.InitCal();
  ls3.InitCal(); ls4.InitCal();
}

void LineSensor::OneCalStep()
{
	ls1.CalcCalibration(); ls2.CalcCalibration();
	ls3.CalcCalibration(); ls4.CalcCalibration();
}

void LineSensor::CalcFilt()
{
  ls1.CalcFilt(); ls2.CalcFilt(); ls3.CalcFilt();
  ls4.CalcFilt(); 
}

void LineSensor::DispRawVals(SvProtocol* aSvp)
{
  aSvp->WriteSvI16(1,ls1.y); aSvp->WriteSvI16(2,ls2.y);
  aSvp->WriteSvI16(3,ls3.y); aSvp->WriteSvI16(4,ls4.y);
}

void LineSensor::DispCalVals(SvProtocol* aSvp)
{
  aSvp->WriteSvI16(1,ls1.CalVal()); aSvp->WriteSvI16(2,ls2.CalVal());
  aSvp->WriteSvI16(3,ls3.CalVal()); aSvp->WriteSvI16(4,ls4.CalVal());
}

void LineSensor::DispMinMax(SvProtocol* aSvp)
{
	aSvp->SvMessage("Min Max");
	for(int i=0; i<N_SENS; i++)
		aSvp->SvPrintf("%d %d",ary[i]->_min, ary[i]->_max);
}














