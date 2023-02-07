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
            WaitForUpdate();

            double dist = 0, phiErr = 0;
            Robot rbFront = RobotMgr.GetNearestInFront(rb, ref dist);

            Vect2D dir;

            while (true)
            {
                WaitForUpdate();

                if (rbFront == null)    // follow mouse if no robot in front
                {
                    // distanz zw maus und robot
                    dist = RobotProg.mpos.DistBetweenPoints(rb.Pos);
                    rb.SetV(KP_FW * dist);

                    // Richtungsvektor robot > maus
                    dir = RobotProg.mpos - rb.Pos;
                    phiErr = dir.DiffAngle(rb.V);
                    rb.Set_dPhi(KP_ANGLE * phiErr);
                }
                else    // follow robot in front
                {
                    dist = rb.Pos.DistBetweenPoints(rbFront.Pos);
                    rb.SetV(KP_FW * dist);

                    dir = rbFront.Pos - rb.Pos;
                    phiErr = dir.DiffAngle(rb.V);
                    rb.Set_dPhi(KP_ANGLE * phiErr);
                }
            }
        }

        void PrgFollowPoints()
        {

        }
        #endregion
    }
}
