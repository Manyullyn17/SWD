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
        }
        public int Get() // Blocks Caller
        {
            return 0;
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
            // thr = new Thread(MainLoop);
            // thr.Start();
        }

        void MainLoop()
        {
            // an der mbx auf einen neuen Auftrag warten
            // wenn neuer Autrag da ProcessWords() aufrufen
        }

        void ProcessWords()
        {
            // Den inTxt char für char word-processen inTxt[i]
            // Nach jeweils 20 Buchstabe die Form benachrichtigen
            // damit das momentane Zwischenergebniss angezeigt werden kann
        }
    }
}
