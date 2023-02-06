using MV;
using System.Collections.Generic;
using System.Drawing;

namespace RobotWorld
{
    class RobotMgr
    {
        static List<RobotProg> _list = new List<RobotProg>();

        public static void CreateRobot(int aPrgNum, Point aMp, double aAngle)
        {
            RobotProg prg = new RobotProg(aPrgNum);
            prg.rb.Pos.SetXY(aMp.X, aMp.Y);
            prg.rb.V.SetFrom_R_Phi(0.01, aAngle);
            Vect2D tmp = Vect2D.Create(1.0, aAngle, true);
            prg.rb.Rotate(tmp);
            _list.Add(prg);
        }

        public static void Paint(Graphics gr)
        {
            foreach (RobotProg prg in _list)
                prg.rb.Paint(gr);
        }

        public static void CalcNextPos()
        {
            foreach (RobotProg prg in _list)
                prg.rb.CalcNextPos();
        }

        public static void UpdatePath()
        {
            foreach (RobotProg prg in _list)
                prg.rb.UpdatePath();
        }

        public static void CleanUp()
        {
            foreach (RobotProg prg in _list)
                prg.thr.Abort();
        }

        public static string GetInfo(Point aMp)
        {
            foreach (RobotProg prg in _list)
            {
                if (prg.rb.HitInRadius(aMp))
                    return prg.progName;
            }
            return "";
        }

        public static void SwitchSuspRes(Point aMp)
        {
            foreach (RobotProg prg in _list)
            {
                if (prg.rb.HitInRadius(aMp))
                    prg.rb.SwitchSuspRes();
            }
        }

        public static Robot GetNearestInFront(Robot aMe, ref double aDist)
        {
            double minDist = 1000;
            Robot minRb = null;

            // Den roboter suchen der mir am nächsten ist
            // und auf mich zufährt
            foreach (RobotProg prg in _list)
            {
                if (prg.rb == aMe) // nicht mit mir selber vergleichen
                    continue;
                Vect2D conn = Vect2D.Create(aMe.Pos, prg.rb.Pos);
                if (conn.ScalarProd(aMe.V) < 0) // check if prog.rb is in Front
                    continue;
                if (aMe.Pos.DistBetweenPoints(prg.rb.Pos) < minDist)
                {
                    minRb = prg.rb;
                    minDist = aMe.Pos.DistBetweenPoints(prg.rb.Pos);
                }
            }
            aDist = minDist;
            return minRb;
        }
    }
}
