
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace vis1
{
  public partial class Form1 : Form
  {
    // es wird ein Array mit Pointern auf labels allokiert
    Label[] m_DispAry = new Label[3];
    SerialPort _ser;
    BinaryReaderEx _rd;
    BinaryWriter _wr;
    
    public Form1()
    {
      InitializeComponent();
      m_DispAry[0] = m_Disp1; m_DispAry[1] = m_Disp2; m_DispAry[2] = m_Disp3;
      m_SendEd.Text = "10";
    }
    
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      _ser = new SerialPort("COM4", 500000, Parity.None, 8, StopBits.One);
      _ser.Open(); // hier kommt die Excepion wenn COM4 nicht da
      _rd = new BinaryReaderEx(_ser.BaseStream);
      _wr = new BinaryWriter(_ser.BaseStream);
      m_Timer1.Interval = 100; // 100msec = 10Hz
      m_Timer1.Enabled = true; // timer starten
    }
    
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      
     
      base.OnFormClosing(e);
    }

    private void OnUCSendChk(object sender, EventArgs e)
    {
      if (m_uCSendChk.Checked) {
        _wr.Write((byte)1); // cmd=1
        _wr.Write((byte)1); // data=1
      }
      else {
        _wr.Write((byte)1); // cmd=1
        _wr.Write((byte)0); // data=0
      }
    }

    private void OnEmptyReceiveBuffer(object sender, EventArgs e)
    {
      
    }

    private void OnTimer(object sender, EventArgs e)
    {
      int id, knr, val;
      float valF;
      while (_ser.BytesToRead > 3)
      {
        id = _ser.ReadByte();
        if (id >= 11 && id <= 20) // int16 Kanal
        {
          knr = id - 10; // offset subtrahieren um auf die Kanalnummer zu kommen
          val = _rd.ReadInt16();
          m_DispAry[knr - 1].Text = val.ToString();
        }
        if (id >= 21 && id <= 30) // float Kanal
        {
          knr = id - 20; // offset subtrahieren um auf die Kanalnummer zu kommen
          valF = _rd.ReadSingle();
          m_DispAry[knr - 1].Text = valF.ToString();
        }
        if (id == 10) // string (Meesage)
        {
          string txt = _rd.ReadCString();
          _msgList.Items.Add(txt);
        }
      }
    }

    private void OnSendEditKeyDown(object sender, KeyEventArgs e)
    {
    }
    
    void OnCommandBtn(object sender, EventArgs e)
    {
      int val1 = int.Parse(m_SendEd.Text);
      int val2 = val1 + 10;
      _wr.Write((byte)4); // cmd
      _wr.Write((short)val1); // data1
      _wr.Write((short)val2); // data2
      _wr.Flush(); // daten senden
    }
  }
}