using MV;
using System.Threading;

namespace RobotWorld
{
    partial class RobotProg
    {
        #region MemberVariables
        public string progName; // Name of executed Robot-Programm
        public Robot rb = new Robot();
        public Thread thr;
        public static object signal = new object();
        #endregion

        public static Vect2D mpos; // MousePosition

        public RobotProg(int aPrgNum)
        {
            switch (aPrgNum)
            {
                case 1:
                    { progName = "Snake"; thr = new Thread(PrgSnake); }
                    break;
                case 2:
                    { progName = "DistTest"; thr = new Thread(PrgDistTest); }
                    break;
                case 3:
                    { progName = "Angle"; thr = new Thread(PrgAngleTest); }
                    break;
                case 4:
                    { progName = "Rasen"; thr = new Thread(PrgRasen1); }
                    break;
                case 5:
                    { progName = "Rect"; thr = new Thread(PrgRectangle); }
                    break;
                case 6:
                    { progName = "Rasen2"; thr = new Thread(PrgRasen2); }
                    break;
                case 7:
                    { progName = "Mouse1"; thr = new Thread(PrgFollowMouse); }
                    break;
                case 8:
                    { progName = "MausZug"; thr = new Thread(PrgMausZug); }
                    break;
                case 9:
                    { progName = "FollowPoints"; thr = new Thread(PrgFollowPoints); }
                    break;
            }
            thr.Start();
        }

        public static void SignalRobots()
        {
            lock (signal)
            {
                Monitor.PulseAll(signal);
            }
        }

        protected void WaitForUpdate()
        {
            lock (signal)
            { Monitor.Wait(signal); }
        }

        void PrgSnake()
        {
            rb.SetV(2); // 2Pix pro Frame vorw.
            while (true)
            {
                WaitForUpdate(); // warten bis es bei der RobotSim was neues gibt
                rb.Set_dPhi(2); // 
                Thread.Sleep(2000);
                WaitForUpdate();
                rb.Set_dPhi(-2);
                Thread.Sleep(2000);
            }
        }
    }
}
