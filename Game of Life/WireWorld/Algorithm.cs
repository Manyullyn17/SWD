using System;
using System.Collections.Generic;
using System.Text;

namespace V1
{
    partial class LifeForm
    {
        // aOld Matrix mit der n-ten Generation
        // aNew Matrix mit der n+1-ten Generation
        void CalcNextGeneration(int[,] aOld, int[,] aNew)
        {
            m_CC = aOld; // sicherstellen, dass m_CC=aOld ist
            int neighbor_count;
            
            for (int j = 0; j < MAX_CELLS; j++)
            {
                for (int i = 0; i < MAX_CELLS; i++)
                {
                    if (m_CC[i, j] == 1)
                        neighbor_count = GetNeighbourCount(i, j);
                    else
                        neighbor_count = 0;

                    // if 1 and neighbor == 1 || neighbor == 2 -> set 2
                    // if 2 -> set 3
                    // if 3 -> set 1

                    if (aOld[i, j] == 1 && (neighbor_count == 1 || neighbor_count == 2))
                        aNew[i, j] = 2;
                    else if (aOld[i, j] == 1)
                        aNew[i, j] = 1;
                    else if (aOld[i, j] == 2)
                        aNew[i, j] = 3;
                    else if (aOld[i, j] == 3)
                        aNew[i, j] = 1;
                }
            }
        }

        void ClearCells(int[,] aCells, bool all=true)
        {
            // alle Zellen von aCells auf false
            if (all)
            {
                for (int j = 0; j < MAX_CELLS; j++)
                {
                    for (int i = 0; i < MAX_CELLS; i++)
                    {
                        aCells[i, j] = 0;
                    }
                }
            } else
            {
                for (int j = 0; j < MAX_CELLS; j++)
                {
                    for (int i = 0; i < MAX_CELLS; i++)
                    {
                        if (aCells[i,j] == 2 || aCells[i,j] == 3)
                            aCells[i, j] = 1;
                    }
                }
            }
        }

        // cells of m_CC
        void SetCellValue(int aX, int aY, int tool)
        {
            // Cell an der Stelle aX,aY toggeln ( Umschalten )
            int X = aX / cell_sizex;
            int Y = aY / cell_sizey;

            if (m_CC[X, Y] == 0 && tool == 1)
                m_CC[X, Y] = 1;
            else if (m_CC[X, Y] == 1 && tool == 1)
                m_CC[X, Y] = 0;
            else if (m_CC[X, Y] == 1 && tool == 2)
                m_CC[X, Y] = 2;
            else if (m_CC[X, Y] == 2 && tool == 2)
                m_CC[X, Y] = 1;
            else if (m_CC[X, Y] == 1 && tool == 3)
                m_CC[X, Y] = 3;
            else if (m_CC[X, Y] == 3 && tool == 3)
                m_CC[X, Y] = 1;
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
                    if (m_CC[itmp, jtmp] == 2)
                        cnt++;
                }
            }
            
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
