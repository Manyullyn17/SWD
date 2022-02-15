using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCalc
{
    public partial class SCalcForm : Form
    {
        double _valA, _valB, _res;
        
        // wird 1x beim Start der App aufgerufen
        public SCalcForm()
        {
            InitializeComponent();
            _inputA.Text = "1,2";
            _inputB.Text = "3,4";
        }

        void Text2Values()
        {
            try
            {
                _valA = Convert.ToDouble(_inputA.Text);
                _valB = Convert.ToDouble(_inputB.Text);
            }
            catch(Exception ex)
            {
                _inputA.Text = "0,0";
                _inputB.Text = "0,0";
                MessageBox.Show("Bitte nur Zahlen eingeben");
            }
        }

        void Values2Text()
        {
            _inputA.Text = Convert.ToString(_res);

        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            // Text int double umwandeln
            // Addieren
            // Resultat in Text verwandeln
            Text2Values();
            _res = _valA + _valB;
            DoTrace(_valA, _valB, _res, '+');
            Values2Text();
        }

        private void OnSubButtonClick(object sender, EventArgs e)
        {
            Text2Values();
            _res = _valA - _valB;
            DoTrace(_valA, _valB, _res, '-');
            Values2Text();
        }

        // DoTrace(3.4, 4.7, 8.1, '+')
        // 8.1 = 3.4 + 4.7
        void DoTrace(double aAVal, double aBVal, double aResVal, char aOperator)
        {
            string txt;

            txt = aResVal.ToString() + " = " + aAVal.ToString();
            txt += " " + aOperator + " " + aBVal.ToString();
            _trcList.Items.Add(txt);
        }
    }
}
