using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SWNW_TCPChat
{
    // Übertragung von Daten via TCP erfolgt durch senden der serialisierten CNetPacket-Struktur via Base64-String
    enum CNetTopic : short
    {
        Message,        // data = string[] { username, message }
        UserListUpdate, // data = string[]
        Disconnect      // data = null
    }

    [Serializable]
    class CNetPacket
    {
        public CNetTopic topic = CNetTopic.Message;
        public object data = null;

        public CNetPacket() { }
        public CNetPacket(CNetTopic _topic, object _data = null)
        {
            topic = _topic;
            data = _data;
        }

        public static string serialize(CNetTopic topic, object _data = null)
        {
            CNetPacket obj = new CNetPacket(topic, _data);
            return obj.serialize();
        }

        public string serialize()
        {
            BinaryFormatter frmt = new BinaryFormatter();
            MemoryStream str = new MemoryStream();
            frmt.Serialize(str, this);

            return Convert.ToBase64String(str.ToArray());
        }

        public void deserialize(byte[] _data)
        {
            string dataStr = Encoding.ASCII.GetString(_data);
            string objStr = dataStr.Substring(0, dataStr.IndexOf('\0'));

            BinaryFormatter frmt = new BinaryFormatter();
            byte[] raw = Convert.FromBase64String(objStr);
            MemoryStream str = new MemoryStream(raw);
            CNetPacket obj = (CNetPacket)frmt.Deserialize(str);
            
            topic = obj.topic;
            data = obj.data;
        }
    }
}
