using System;
// using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.Threading;

namespace WordProc
{
    // Dieselbe MailBox-Idee wie im Request/Response Beispiel
    class MailBox
    {
        int msg;
        public void Put(int aMsg) // Signals waiting Thread
        {
            // oder lock(this) um alles anstann enter und exit
            Monitor.Enter(this);
            msg = aMsg;
            Monitor.Pulse(this);
            Monitor.Exit(this);
        }
        public int Get() // Blocks Caller
        {
            Monitor.Enter(this);
            Monitor.Wait(this);
            int ret = msg;
            msg = -1;
            Monitor.Exit(this);
            return ret;
        }
    }

    class WordProc
    {
        public Thread thr;
        public string inTxt; // der zu verarbeitende Input-Text

        // der word-processte output-Text
        public StringBuilder outTxt = new StringBuilder(2000);

        public MailBox mbx = new MailBox(); // Mailbox of Worker

        public WordProc()
        {
            thr = new Thread(MainLoop);
            thr.Start();
        }

        void MainLoop()
        {
            // an der mbx auf einen neuen Auftrag warten
            // wenn neuer Autrag da ProcessWords() aufrufen

            while (true)
            {
                mbx.Get();
                ProcessWords();
            }
        }

        void ProcessWords()
        {
            // Den inTxt char für char word-processen inTxt[i]
            // Nach jeweils 20 Buchstabe die Form benachrichtigen
            // damit das momentane Zwischenergebniss angezeigt werden 
            
            for (int i = 0; i < inTxt.Length; i++)
            {
                Thread.Sleep(20);

                char c = inTxt[i];
                outTxt.Append(c);

                if(char.IsLetterOrDigit(c))
                {
                    outTxt.Append('.');
                }

                if((i % 20 == 0) && (i != 0))
                {
                    Form1.frm.SendMessage2Form(1);
                }
            }

            Form1.frm.SendMessage2Form(1);
        }
    }
}
