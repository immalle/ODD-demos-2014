using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
            this.Visible = false;
        }
        // Namen ingeven.
        private void button2_Click(object sender, EventArgs e)
        {

            label1.Text = "Wat zijn uw namen?";
            

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            speler1.Visible = true;
            speler2.Visible = true;
            Back.Visible = true;
        }
        // Namen doorgeven + naar spel gaan.
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            
            frm2.label3.Text = speler1.Text;
            frm2.label4.Text = speler2.Text;

            this.Visible = false;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            speler1.Visible = false;
            speler2.Visible = false;
            Back.Visible = false;
            label1.Text = "Kies uw spel";
        }
    }
}
