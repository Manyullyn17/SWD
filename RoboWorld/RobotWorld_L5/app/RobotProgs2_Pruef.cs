using System;
using System.Threading;
using MV;

namespace RobotWorld
{
  partial class RobotProg
  {
    #region Usefull Functions
    void Turn2Target(Vect2D aT, double aRotSpeed)
    {
    }

    void Drive2Target(Vect2D aT, double aSpeed, double aDPhi)
    {
    }
    #endregion

    const double MOUSE_MIN_DIST = 50;
    const double KP_FW = 0.1;
    const double KP_ANGLE = 0.5;

    #region Programms
    void PrgFollowMouse()
    {
    }
    
    void PrgMausZug()
    {
    }

    void PrgFollowPoints()
    {
      WaitForUpdate();
      int i;
      while (true)
      {
        WaitForUpdate();
        for (i = 0; i < Omgr.Count; i++)
        {
          Turn2Target(Omgr.At(i).pos, 5);
          TurnRelAngle(40, 5);
          Drive2Target(Omgr.At(i).pos, 6, 4);
        }
      }
    }
    #endregion
  }
}
