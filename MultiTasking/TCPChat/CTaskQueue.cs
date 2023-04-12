using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Threading;

namespace SWNW_TCPChat
{
    enum CWhatToDo
    {
        INVALID,

        // ----- Serverseitig ----- //
        sTerminate,         // data = null; sender = null;
        sStoreClient,       // data = null; sender = Client;
        sRemoveClient,      // data = null; sender = Client;
        sForwardMessage,    // data = string; sender = Client;

        scTerminate,        // data = null; sender = null;
        scSendMessage,      // data = string; sender = Client(der, der die Nachricht gesendet hat);
        scSendClientList,   // data = string[]; sender = null;

        // ----- Clientseitig ----- //
        cTerminate,         // data = null; sender = null;
        cSendMessage        // data = string; sender = null;
    }
    class CTask
    {
        public CTask() { }
        public CTask(CWhatToDo _task, object _data = null, object _sender = null)
        {
            task = _task;
            data = _data;
            sender = _sender;
        }
        public CWhatToDo task = CWhatToDo.INVALID;
        public object data = null;
        public object sender = null;
    }
    class CTaskQueue
    {
        private Queue<CTask> m_queue = null;
        public CTaskQueue()
        {
            m_queue = new Queue<CTask>();
        }
        public void put(CTask task)
        {
            Monitor.Enter(m_queue);
            m_queue.Enqueue(task);
            Monitor.Pulse(m_queue);
            Monitor.Exit(m_queue);
        }
        
        public CTask get()
        {
            Monitor.Enter(m_queue);
            if(m_queue.Count == 0) Monitor.Wait(m_queue);   // Wenn queue leer ist warten; ansonsten direkt weitermachen
            CTask task = m_queue.Dequeue();
            Monitor.Exit(m_queue);
            return task;
        }
    }
}
