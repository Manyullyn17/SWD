
#ifndef SvProtocol_h
#define SvProtocol_h

#include "stdint.h"

namespace mbed {

class IStreamHL {
	public:
		virtual void PutChar(int aCh) = 0;
		virtual int GetChar() = 0;
		virtual void Write(void* aData, uint32_t aLenBytes) = 0;
		virtual void Read(void* aData, uint32_t aLenBytes) = 0;
		virtual int ReadUntil(char* aBuff, char aMarker) = 0;
		virtual void Flush() { }
};

class SvProtocol {
	public:
		IStreamHL* _st;
		uint8_t acqON;
    uint8_t svMessageON;
		uint8_t useTags;
	public:
		SvProtocol(IStreamHL* aStrm) {
			acqON=0; svMessageON=1; useTags=1;
			_st=aStrm; 
		}
	
		// Check's first for acqOn/Off Command
    // ret 0 if acqOn/Off was handled in GetCommand
    int GetCommand();
		
		void Puts(char* aCStr); // Terminate with 0

		void Puts2(char* aCStr); // NOT!! Terminated with 0

    // \r\n is appended automatically
    void Printf(const char* format, ...);

    void SvPrintf(const char *format, ...);
    
    void WriteSV(int aId, char* aData) {
      if( !svMessageON ) return;
      _st->PutChar(aId); Puts(aData); 
    }
    
    void SvMessage(char* aTxt) {
      if( !svMessageON ) return;
			if( useTags ) _st->PutChar(10); 
			Puts(aTxt);
    }
    
    void VectHeader(int aId, int aNVals)
      { _st->PutChar(aId); _st->PutChar(aNVals); }
    
    void WriteSvI16(int aId, int16_t aData)
      { _st->PutChar(aId+10); _st->Write(&aData,2); }
    
    void WriteSvI32(int aId, int32_t aData)
      { _st->PutChar(aId); _st->Write(&aData,4); }
    
    void WriteSV(int aId, float aData)
      { _st->PutChar(aId+20); _st->Write(&aData,4); }

		void WriteSV(int aId, float aData[], int aCnt) {
			for(int i=0; i<aCnt; i++)
				WriteSV(i+aId, aData[i]);
		}
			
		// aLen = Anzahl gültiger Werte in aAry	
		void WriteArray(int16_t aAry[], int aLen)
		{
			_st->PutChar(100); // Id für array
			_st->PutChar(aLen); // Länge als Byte geschrieben
			for(int i=0; i<aLen; i++)
			{
				_st->Write(&(aAry[i]),2); // jeder Arrayeintrag als int16
			}
		}
    
    // float in 3.13 Format
    void WriteSV3p13(int aId, float aData);

    int16_t ReadI16()
      { int16_t ret; _st->Read(&ret,2); return ret; }

    int32_t ReadI32()
      { int32_t ret; _st->Read(&ret,4); return ret; }
    
    float ReadF()
      { float ret; _st->Read(&ret,4); return ret; }

		SvProtocol& WrB(char aVal)
      { _st->PutChar(aVal); return *this; }
    
    SvProtocol& WrF(float aVal)
      { _st->Write(&aVal,4); return *this; }
};

} // namespace mbed

// SV-Id Ranges and DataTypes for SvVis3 Visualisation-Tool
//----------------------------------------------------------
// Id = 10       : string
// Id = 1 .. 9   : format 3.13  2 Bytes
// Id = 11 .. 20 : short        2 Bytes
// Id = 21 .. 30 : float        4 Bytes
// Id = 100      : int16-Array

#endif
