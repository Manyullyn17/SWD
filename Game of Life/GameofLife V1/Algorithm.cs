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
            m_CC = aOld; // sicherstellen, dass m_CC=aOld ist
            int neighbor_count;

            for (int j = 0; j < MAX_CELLS; j++)
            {
                for (int i = 0; i < MAX_CELLS; i++)
                {
                    neighbor_count = GetNeighbourCount(i, j);

                    if (aOld[i, j] == false)
                    {
                        if (neighbor_count == 3)
                            aNew[i, j] = true;
                    } 
                    else
                    {
                        if (neighbor_count < 2)
                            aNew[i, j] = false;
                        if (neighbor_count > 3)
                            aNew[i, j] = false;
                        if (neighbor_count == 2 || neighbor_count == 3)
                            aNew[i, j] = true;
                    }
                }
            }
        }

        void ClearCells(bool[,] aCells)
        {
            // alle Zellen von aCells auf false
            for (int j = 0; j < MAX_CELLS; j++)
            {
                for (int i = 0; i < MAX_CELLS; i++)
                {
                    aCells[i, j] = false;
                }
            }
        }

        // cells of m_CC
        void TurnCellOnOff(int aX, int aY)
        {
            // Cell an der Stelle aX,aY toggeln ( Umschalten )
            int X = aX / CELL_SIZE;
            int Y = aY / CELL_SIZE;

            m_CC[X, Y] = !m_CC[X, Y];
        }
    
        // cells of m_CC
        int GetNeighbourCount(int i, int j)
        {
            // wieviele lebende Nachbarn hat Cell(i,j)
            int cnt = 0;
            int itmp;
            int jtmp;

            for (int i2 = i-1; i2 <= i+1; i2++)
            {
                for (int j2 = j-1; j2 <= j+1; j2++)
                {
                    itmp = i2;
                    jtmp = j2;
                    if (i2 < 0)
                        itmp = MAX_CELLS - 1;
                    if (j2 < 0)
                        jtmp = MAX_CELLS - 1;
                    if (i2 > MAX_CELLS - 1)
                        itmp = 0;
                    if (j2 > MAX_CELLS - 1)
                        jtmp = 0;
                    if (m_CC[itmp, jtmp] == true)
                        cnt++;
                }
            }

            if (m_CC[i, j] == true)
                cnt--;

            return cnt;
        }

        // Ist Cell(i,j) von m_CC on oder off ?
        // mit richtiger Behandlung von i,j<0 und i,j>=MAX_CELLS
        bool ValOf(int i, int j)
        {
            return true;
        }

    }
}
