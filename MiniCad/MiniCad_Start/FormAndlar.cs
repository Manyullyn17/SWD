using System;
// using System.Collections.Generic;
using System.Collections;
// using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
Aufgabenstellung:

1) Implemetieren Sie 2 von GraphicObject abgeleitete
   Klassen mit unterschiedlichem Aussehen 
   wie z.B. Rectangle und Circle

2) Funktionalität:
   Erzeugen und Löschen von Objekten 
   ( der Typ Rect/Circle kann ausgewählt werden )
   Trefferprüfung über HitInRadius

3) Verwaltung und übergeordneter Code
   für Erzeugen, Löschen, Paint, Trefferprüfung 
   soll in einer Manager-Klasse GrObjMgr sein
*/

namespace Andlar
{
    public partial class FormAndlar : Form
    {
        public FormAndlar()
        {
            InitializeComponent();
            GraphicObject.SetDefaultColors(_panel.BackColor, Color.Red);
            _sizeEd.Text = "10"; _typeEd.Text = "R";
        }
    }
}
