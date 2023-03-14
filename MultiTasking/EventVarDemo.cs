using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace prj
{
  class SignalingDemo
  {
    int gCnt;
    object sigObj = new Object();

    static void Main(string[] args)
    {
      SignalingDemo d3 = new SignalingDemo();
      d3.MainProg();
    }
    
    void MainProg()
    {
      Thread ta, tb;
      ta = new Thread(this.SenderThread); ta.Priority = ThreadPriority.Lowest;
      tb = new Thread(this.ReceiverThread); tb.Priority = ThreadPriority.Lowest;
      
      ta.Start(); tb.Start();
      Console.WriteLine("\nHit Enter to finish.....");
      Console.ReadLine();
      
      ta.Abort(); tb.Abort();
    }

    void SenderThread()
    {
      while (true)
      {
        Console.WriteLine("Sender: {0}", ++gCnt);
        lock (sigObj) {
          Monitor.Pulse(sigObj);
        }
        Thread.Sleep(200);
      }
    }

    void ReceiverThread()
    {
      while (true)
      {
        lock (sigObj) {
          Monitor.Wait(sigObj);
          if (gCnt % 5 == 0)
            Console.WriteLine("!! Receiver: {0}", gCnt);
        }
      }
    }
  }
}
