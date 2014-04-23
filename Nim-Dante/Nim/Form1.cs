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
    public partial class Form1 : Form
    {
        Form3 form3;
        int x;
        int y;
        int a;
        int z;
        int r;
        public Form1()
        {
            form3 = new Form3();
            InitializeComponent();         
        }
        // start knop
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;

            Random rndgen = new Random();
            int x = rndgen.Next(0, 200);
            int y = rndgen.Next(0, 200);
            int z = rndgen.Next(0, 200);

            stapel1.Text = Convert.ToString(x);
            stapel2.Text = Convert.ToString(y);
            stapel3.Text = Convert.ToString(z);
        }
        // Restart knop
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            
            stapel1.Text = "Stapel1";
            stapel2.Text = "Stapel2";
            stapel3.Text = "Stapel3";
        }
        // speler
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Voer een getal in beide balken alstublieft.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Voer een getal in beide balken alstublieft.");
            }
            else
            {

                x = Convert.ToInt32(textBox1.Text);
                y = Convert.ToInt32(textBox2.Text);
            
            if (x == 1)
            {
                int res = Convert.ToInt32(stapel1.Text) - y;
                if (res < 0)
                {
                    res = 0;
                }
                if (Convert.ToInt32(stapel1.Text) == 0)
                {
                    MessageBox.Show("Gebruik een andere stapel, deze is leeg.");
                }
                stapel1.Text = Convert.ToString(res);
                
            }
            else if (x == 2)
            {
                int res = Convert.ToInt32(stapel2.Text) - y;
                if (res < 0)
                {
                    res = 0;
                }
                if (Convert.ToInt32(stapel2.Text) == 0)
                {
                    MessageBox.Show("Gebruik een andere stapel, deze is leeg.");
                }
                stapel2.Text = Convert.ToString(res);
            }
            else if (x == 3)
              {
                int res = Convert.ToInt32(stapel3.Text) - y;
                if (res < 0)
                {
                    res = 0;
                }
                if (Convert.ToInt32(stapel3.Text) == 0)
                {
                    MessageBox.Show("Gebruik een andere stapel, deze is leeg.");
                }
                stapel3.Text = Convert.ToString(res);
              }
            
            button4.Visible = true;
            button3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            }
        }
        // AI
        private void button4_Click(object sender, EventArgs e)
        {
            
            int x = Convert.ToInt32(stapel1.Text);
            int y = Convert.ToInt32(stapel2.Text);
            int z = Convert.ToInt32(stapel3.Text);
            if (x + y + z == 1)
            {
                MessageBox.Show("Game over. Jij wint.");
            }

            else if (!(x + y + z == 0))
            {
                Random rndgen = new Random();
                int stapelnr = rndgen.Next(2);

                if (stapelnr == 0)
                {
                    int afname = rndgen.Next(Convert.ToInt32(stapel1.Text));

                    int res = Convert.ToInt32(stapel1.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel1.Text = Convert.ToString(res);
                }
                else if (stapelnr == 1)
                {
                    int afname = rndgen.Next(Convert.ToInt32(stapel2.Text));

                    int res = Convert.ToInt32(stapel2.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel2.Text = Convert.ToString(res);
                }
                else if (stapelnr == 2)
                {
                    int afname = rndgen.Next(Convert.ToInt32(stapel3.Text));

                    int res = Convert.ToInt32(stapel3.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel3.Text = Convert.ToString(res);
                }
            }
            else if (z == 0)
            {
                Random rndgen = new Random();
                int stapelnr = rndgen.Next(1);
                int afname = rndgen.Next(200);

                if (stapelnr == 0)
                {
                    int res = Convert.ToInt32(stapel1.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel1.Text = Convert.ToString(res);
                }
                else if (stapelnr == 1)
                {
                    int res = Convert.ToInt32(stapel2.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel2.Text = Convert.ToString(res);
                }
            }
            else if (y == 0)
            {
                Random rndgen = new Random();
                int stapelnr = rndgen.Next(1);

                if (stapelnr == 0)
                {
                    int afname = rndgen.Next(Convert.ToInt32(stapel1.Text));

                    int res = Convert.ToInt32(stapel1.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel1.Text = Convert.ToString(res);
                }
                else if (stapelnr == 1)
                {
                    int afname = rndgen.Next(Convert.ToInt32(stapel3.Text));

                    int res = Convert.ToInt32(stapel3.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel3.Text = Convert.ToString(res);
                }

            }
            else if (x == 0)
            {
                Random rndgen = new Random();
                int stapelnr = rndgen.Next(1);

                if (stapelnr == 0)
                {
                    int afname = rndgen.Next(Convert.ToInt32(stapel2.Text));

                    int res = Convert.ToInt32(stapel2.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel2.Text = Convert.ToString(res);
                }
                else if (stapelnr == 1)
                {
                    int afname = rndgen.Next(Convert.ToInt32(stapel3.Text));

                    int res = Convert.ToInt32(stapel3.Text) - afname;
                    if (res < 0)
                    {
                        res = 0;
                    }
                    stapel3.Text = Convert.ToString(res);
                }
            }
             if (x + y == 0)
            {
                stapel3.Text = "1";
                MessageBox.Show("Game over, computer wint");
            }
             if (x + z == 0)
            {
                stapel2.Text = "1";
                MessageBox.Show("Game over, computer wint");
            }
             if (y + z == 0)
            {
                stapel1.Text = "1";
                MessageBox.Show("Game over, computer wint");
            }

            button4.Visible = false;
            button3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
        }
        // Quit knop
        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
            form3.Show();
        }
    }
}
