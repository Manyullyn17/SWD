using System;
using System.Threading;
using MV;

namespace RobotWorld
{
  partial class RobotProg
  {
    #region Usefull Functions
    
    void DriveDistance(double aPow, double aDist)
    {
      Vect2D start = rb.Pos;
      rb.SetV(aPow); // Motoren ein
      while (true)
      {
        // Warten bis die Simulation eine neue Pos berchnet hat
        WaitForUpdate(); 
        if (start.DistBetweenPoints(rb.Pos) > aDist)
          break;
      }
      rb.SetV(0); // Motoren aus
    }

    // Turn aPhi from current Heading
    void TurnRelAngle(double aPhi, double aRotSpeed)
    {
      // Gyro Sensor auf 0 setzen
      rb.GyroAngle = 0;
      if (aPhi > 0)
      {
        rb.Set_dPhi(aRotSpeed); // Motoren einschalten
        while (rb.GyroAngle < aPhi)
          WaitForUpdate();
      }
      else // aPhi < 0
      {
        rb.Set_dPhi(-aRotSpeed);
        while (rb.GyroAngle > aPhi)
          WaitForUpdate();
      }
      rb.Set_dPhi(0); // Motoren ausschalten
    }

    // aPhi must be within +/- 180°
    void TurnAbsAngle(double aPhi, double aRotSpeed)
    {
      if (aPhi == rb.GetPhi())
        return;
      if (aPhi > 0)
      {
        rb.Set_dPhi(aRotSpeed); // Mot ein
        while (rb.GetPhi() < aPhi)
          WaitForUpdate();
        rb.Set_dPhi(0); // Mot aus
      }
      else // aPhi < 0
      {
        rb.Set_dPhi(-aRotSpeed); // Mot ein
        while (rb.GetPhi() > aPhi)
          WaitForUpdate();
        rb.Set_dPhi(0); // Mot aus
      }
    }

    void TurnAbsAngleInteligent(double aPhi, double aRotSpeed)
    {
    }
    #endregion

    const double FW_SPEED = 5;
    const double TURN_SPEED = 5;
    const double COL_DIST = 50;

    #region Programms

    void PrgAngleTest()
    {
      while (true)
      {
        while (true)
        {
          TurnAbsAngle(45, 5);
          TurnAbsAngle(-45, 5);
        }
      }
    }

    void PrgDistTest()
    {
      while (true)
      {
        DriveDistance(5, 100);
        DriveDistance(-5, 100);
      }
    }

    void PrgRectangle()
    {
      while (true)
      {
        DriveDistance(5, 150);
        TurnRelAngle(90, 5);
      }
    }

    void PrgRasen1()
    {
      // DblBuffForm.XMin;
      // DblBuffForm.XMax;
      // DblBuffForm.YMin;
      // DblBuffForm.YMax;
    }
    
    void PrgRasen2()
    {
    }

    bool CheckCollision()
    {
      return false;
    }
    #endregion
  }
}
