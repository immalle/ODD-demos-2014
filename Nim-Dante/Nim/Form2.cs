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
    public partial class Form2 : Form
    {
        Form3 form;
        public string S1;
        public string S2;

        public Form2()
        {
            InitializeComponent();
            form = new Form3();
        }

        //switch naam speler
        private void button4_Click(object sender, EventArgs e)
        {
            string temp;

            temp = label3.Text;
            label3.Text = label4.Text;
            label4.Text = temp;

            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;

            int a = Convert.ToInt32(stapel1.Text);
            int z = Convert.ToInt32(stapel2.Text);
            int r = Convert.ToInt32(stapel3.Text);

            if (a + z + r <= 1)
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

                string b = label4.Text;

                MessageBox.Show("Game over, " + b + " wint.");
            }
        }
        //start knop
        private void button1_Click_1(object sender, EventArgs e)
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
        //Restart
        private void button2_Click_1(object sender, EventArgs e)
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
        //Quit
        private void button5_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
        }
        //Game
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) > 3)
            {
                MessageBox.Show("Geef een getal tussen 1 en 3 alstublieft");
            }
            
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
                int x = Convert.ToInt32(textBox1.Text);
                int y = Convert.ToInt32(textBox2.Text);
                int a = Convert.ToInt32(stapel1.Text);
                int z = Convert.ToInt32(stapel2.Text);
                int r = Convert.ToInt32(stapel3.Text);

                if (x == 1)
                {
                    if (Convert.ToInt32(stapel1.Text) == 0)
                    {
                        MessageBox.Show("Gebruik een andere stapel, deze is leeg.");
                    }
                    else
                    {
                        int res = Convert.ToInt32(stapel1.Text) - y;
                        if (res < 0)
                        {
                            res = 0;
                        }
                        stapel1.Text = Convert.ToString(res);

                        button4.Visible = true;
                        button3.Visible = false;
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                    }  

                }
                else if (x == 2)
                {
                    if (Convert.ToInt32(stapel2.Text) == 0)
                    {
                        MessageBox.Show("Gebruik een andere stapel, deze is leeg.");
                    }
                    else
                    {
                        int res = Convert.ToInt32(stapel2.Text) - y;
                        if (res < 0)
                        {
                            res = 0;
                        }
                        stapel2.Text = Convert.ToString(res);

                        button4.Visible = true;
                        button3.Visible = false;
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                    }  
                }
                else if (x == 3)
                {
                    if (Convert.ToInt32(stapel3.Text) == 0)
                    {
                        MessageBox.Show("Gebruik een andere stapel, deze is leeg.");
                    }            
                    else
                    {
                        int res = Convert.ToInt32(stapel3.Text) - y;
                        if (res < 0)
                        {
                            res = 0;
                        }
                        stapel3.Text = Convert.ToString(res);

                        button4.Visible = true;
                        button3.Visible = false;
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                    }  
                    
                }               
                
            }

        }
    }
}
