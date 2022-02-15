using System;
using System.Collections.Generic;
using System.Text;

namespace V1
{
  partial class LifeForm
  {
    // aOld Matrix mit der n-ten Generation
    // aNew Matrix mit der n+1-ten Generation
    void CalcNextGeneration(bool[,] aOld, bool[,] aNew)
    {
      m_CC = aOld; // sicherstellen, daﬂ m_CC=aOld ist
    }

    void ClearCells(bool[,] aCells)
    {
      // alle Zellen von aCells auf false
    }

    // cells of m_CC
    void TurnCellOnOff(int aX, int aY)
    {
      // Cell an der Stelle aX,aY toggeln ( Umschalten )
    }
    
    // cells of m_CC
    int GetNeighbourCount(int i, int j)
    {
      // wieviele lebende Nachbarn hat Cell(i,j)
      return 0;
    }

    // Ist Cell(i,j) von m_CC on oder off ?
    // mit richtiger Behandlung von i,j<0 und i,j>=MAX_CELLS
    bool ValOf(int i, int j)
    {
      return true;
    }

  }
}
