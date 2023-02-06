using MV;

namespace RobotWorld
{
    partial class RobotProg
    {
        #region Useful Functions
        #endregion

        const double MOUSE_MIN_DIST = 50;
        const double KP_FW = 0.1;
        const double KP_ANGLE = 0.5;

        #region Programms
        void PrgFollowMouse()
        {
            double dist = 0, phiErr = 0;
            Vect2D dir;
            while (true)
            {
                // distanz zw maus und robot
                dist = RobotProg.mpos.DistBetweenPoints(rb.Pos);
                rb.SetV(KP_FW * dist);

                // Richtungsvektor robot > maus
                dir = RobotProg.mpos - rb.Pos;
                phiErr = dir.DiffAngle(rb.V);
                rb.Set_dPhi(KP_ANGLE * phiErr);
                WaitForUpdate();
            }
        }

        void PrgMausZug()
        {
            // HW
            double dist = 0, phiErr = 0;
            Robot rb2 = RobotMgr.GetNearestInFront(rb, ref dist);

            Vect2D dir;

            while (true)
            {
                // distanz zw maus und robot
                dist = RobotProg.mpos.DistBetweenPoints(rb.Pos);
                rb.SetV(KP_FW * dist);

                // Richtungsvektor robot > maus
                dir = RobotProg.mpos - rb.Pos;
                phiErr = dir.DiffAngle(rb.V);
                rb.Set_dPhi(KP_ANGLE * phiErr);

                // robot 2? idfk
                dir = rb2.Pos - rb.Pos;
                phiErr = dir.DiffAngle(rb.V);
                rb.Set_dPhi(KP_ANGLE * phiErr);
                WaitForUpdate();
            }
            // rb2.Pos
        }

        void PrgFollowPoints()
        {

        }
        #endregion
    }
}
