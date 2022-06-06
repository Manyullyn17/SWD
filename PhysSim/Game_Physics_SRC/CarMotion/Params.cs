
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace HLSpaceShip
{
  // Alle Simulations und Physik-Parameter werden zentral
  // an einer Stelle gesetzt
	public class Par
	{
    public const int TIMER_INTERVAL = 50; // in ms
		
    public const int ITER_PER_TICK = 1; // 5
    
    public const double DT = 1.0/(double)ITER_PER_TICK;
    
    public const double KR = 0.01*DT; // Reibungskonstante im Medium

    // Achtung!! hier kein DT
    public const double KRW = 0.1; // Reibungskonstante bei Reflexion

    // Vn+1 = Vn - Vn*KR;
    // Vn+1 = Vn*(1 - KR);
    public const double KR_CALC = 1 - KR;

    public const double KRW_CALC = 1 - KRW;

    public const double EARTH_ACCEL = 0.5 * DT;
		
    public const double EPS_V = 1E-3;
    
    public const double COLLIDE_DIST = 25;
	}
}
