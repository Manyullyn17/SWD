
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Balls6
{
  // Alle Simulations und Physik-Parameter werden zentral
  // an einer Stelle gesetzt
	public class Par
	{
    // Geschwindigkeitseinheit ist Pixel pro TimerTick
    public const int TIMER_INTERVAL = 20; // 20  in ms
		
    // wie oft wird die Physik pro FrameUpdate gerechnet
    public const int ITER_PER_TICK = 2; // 5
    
    public const double DT = 1.0/(double)ITER_PER_TICK;
    
    // (Kr/m)*dt
    public const double KR = 0.000*DT; // Reibungskonstante im Medium  0.02

    // Achtung!! hier kein DT
    public const double KRW = 0.1; // Reibungskonstante bei Reflexion

    // Vn+1 = Vn - Vn*KR;
    // Vn+1 = Vn*(1 - KR);
    public const double KR_CALC = 1 - KR;

    public const double KRW_CALC = 1 - KRW;

    public const double EARTH_ACCEL = 0.8 * DT;
		
    public const double EPS_V = 1E-3;
    
    public const double COLLIDE_DIST = 25;
	}
}
