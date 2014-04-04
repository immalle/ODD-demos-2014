using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiimoteLib;

namespace Space_Cube_Adventures
{
    public partial class Form1 : Form
    {
        //INTS
        int intPlayerHealth = 100;
        int intEnemyHealth;
        int intEnemy2Health;
        int intEnemy3Health;
        int intDamageFromEnemy = 25;
        int intPlayerSize = 75;
        int intEnemySize = 50;
        int intSpeed = 10;
        int intScore = 0;
        int intScorePS = 1;
        
        //PICTURBOXES
        PictureBox picAchtergrond;
        PictureBox picDown;
        PictureBox picUp;
        PictureBox picPlayer;
        PictureBox picPlayerHealth;
        PictureBox picEnemy;
        PictureBox picEnemy2;
        PictureBox picEnemy3;
        
        //WIIMOTE
        Wiimote wm = new Wiimote();
        

        //BOOLS
        bool NunLinks;
        bool NunRechts;
        bool NunOnder;
        bool NunBoven;
        bool NunStil;

        //TIMER
        Timer timFPS;
        Timer timTutorial;
        Timer timRumble;
        Timer timSpeed;

        //Labels
        Label lblScore;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            picAchtergrond = new PictureBox();
            picAchtergrond.Width = this.Width;
            picAchtergrond.Height = this.Height;
            picAchtergrond.Image = Space_Cube_Adventures.Properties.Resources.STARTSCHERM;
            picAchtergrond.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(picAchtergrond);

            //wiimote connect
            wm.Connect();
            wm.SetLEDs(true, true, true, true);

            Cursor.Hide();
        }

        void Tutorial() 
        {
            //RESET
            ///INTS
            intDamageFromEnemy = 20;
            intPlayerSize = 75;
            intEnemySize = 50;
            intSpeed = 15;
            
            Controls.Remove(picAchtergrond);
            this.BackColor = Color.Black;

            timTutorial = new Timer();
            timTutorial.Interval = 6000;
            timTutorial.Tick += timTutorial_Tick;
            timTutorial.Start();
            
        }

        void timTutorial_Tick(object sender, EventArgs e)
        {
            timTutorial.Stop();
            Game();
        }

        void Game()
        {
            Controls.Remove(picAchtergrond);
            wm.SetLEDs(true, true, true, true);

            picPlayerHealth = new PictureBox();
            picPlayerHealth.Location = new System.Drawing.Point(322, 960);
            picPlayerHealth.Size = new Size(354, 62);
            picPlayerHealth.Image = Space_Cube_Adventures.Properties.Resources.GreenHealthbar;
            Controls.Add(picPlayerHealth);

            lblScore = new Label();
            lblScore.Location = new System.Drawing.Point(800, 960);
            lblScore.BackColor = Color.Blue;
            lblScore.BackColor = Color.Red;
            Controls.Add(lblScore);
            
            picUp = new PictureBox();
            picUp.Location = new System.Drawing.Point(0, 0);
            picUp.Size = new Size(1680, 113);
            picUp.Image = Space_Cube_Adventures.Properties.Resources.BorderUp;
            Controls.Add(picUp);

            picDown = new PictureBox();
            picDown.Location = new System.Drawing.Point(0, 938);
            picDown.Size = new Size(1680, 112);
            picDown.Image = Space_Cube_Adventures.Properties.Resources.BorderDown;
            Controls.Add(picDown);

            

            this.BackColor = Color.Black;
            
            intPlayerHealth = 100;
            intEnemyHealth = 50;
            intEnemy2Health = 50;
            intEnemy3Health = 50;
            
            picPlayer = new PictureBox();
            picPlayer.Size = new Size(intPlayerSize, intPlayerSize);
            picPlayer.Location = new System.Drawing.Point(300, 625);
            picPlayer.Image = Space_Cube_Adventures.Properties.Resources.Lazer0;
            picPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(picPlayer);
            
            picEnemy = new PictureBox();
            picEnemy.Size = new Size(intEnemySize, intEnemySize);
            picEnemy.Location = new System.Drawing.Point(this.Width + 100, 200);
            picEnemy.Image = Space_Cube_Adventures.Properties.Resources.Enemy0;
            picEnemy.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(picEnemy);

            picEnemy2 = new PictureBox();
            picEnemy2.Size = new Size(intEnemySize, intEnemySize);
            picEnemy2.Location = new System.Drawing.Point(this.Width + 100, 500);
            picEnemy2.Image = Space_Cube_Adventures.Properties.Resources.Enemy0;
            picEnemy2.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(picEnemy2);

            picEnemy3 = new PictureBox();
            picEnemy3.Size = new Size(intEnemySize, intEnemySize);
            picEnemy3.Location = new System.Drawing.Point(this.Width + 100, 800);
            picEnemy3.Image = Space_Cube_Adventures.Properties.Resources.Enemy0;
            picEnemy3.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(picEnemy3);
            
            wm.WiimoteChanged += wm_WiimoteChanged;

            timFPS = new Timer();
            timFPS.Interval = 5;
            timFPS.Tick += FPS_Tick;
            timFPS.Start();

            timRumble = new Timer();
            timRumble.Interval = 500;
            timRumble.Tick += timRumble_Tick;

            timSpeed = new Timer();
            timSpeed.Interval = 5000;
            timSpeed.Tick += timSpeed_Tick;
            timSpeed.Start();


        }

        void timSpeed_Tick(object sender, EventArgs e)
        {
            intSpeed++;
            intScorePS++;
        }

        
        void FPS_Tick(object sender, EventArgs e)
        {
            //MOVE B*TCH
            picEnemy.Location = new System.Drawing.Point(picEnemy.Location.X - (intSpeed + 2), picEnemy.Location.Y);
            picEnemy2.Location = new System.Drawing.Point(picEnemy2.Location.X - (intSpeed), picEnemy2.Location.Y);
            picEnemy3.Location = new System.Drawing.Point(picEnemy3.Location.X - (intSpeed - 2), picEnemy3.Location.Y);

            //MOVE PLAYER
            PlayerMovement();
            
            //SCORE
            intScore = intScore + intScorePS;
            lblScore.Text = (intScore/100).ToString();
            
            //LEFT TO RIGHT
            Endlap(picEnemy);
            Endlap(picEnemy2);
            Endlap(picEnemy3);

            //COLLISION
            PlayerCollision(picEnemy);
            PlayerCollision(picEnemy2);
            PlayerCollision(picEnemy3);
        }

        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {
            WiimoteState ws = e.WiimoteState;

            if (ws.ExtensionType == ExtensionType.Nunchuk)
            {
                
                if (ws.NunchukState.Joystick.Y > 0.05)
                {
                    NunRechts = false;
                    NunLinks = false;
                    NunBoven = true;
                    NunOnder = false;
                    NunStil = false;
                    
                }
                else if (ws.NunchukState.Joystick.Y < -0.05)
                {
                    NunRechts = false;
                    NunLinks = false;
                    NunBoven = false;
                    NunOnder = true;
                    NunStil = false;
                    
                }
                else if (ws.NunchukState.Joystick.Y < 0.05 && ws.NunchukState.Joystick.Y > -0.05)
                {
                    NunRechts = false;
                    NunLinks = false;
                    NunBoven = false;
                    NunOnder = false;
                    NunStil = true;
                }
            }
        }

        void PlayerMovement()
        { 
            if(NunBoven)
            {picPlayer.Location = new System.Drawing.Point(picPlayer.Location.X,picPlayer.Location.Y - 8);}
            else if (NunOnder)
            { picPlayer.Location = new System.Drawing.Point(picPlayer.Location.X, picPlayer.Location.Y + 8); }
            else if (NunRechts)
            { picPlayer.Location = new System.Drawing.Point(picPlayer.Location.X + 5, picPlayer.Location.Y); }
            else if (NunLinks)
            { picPlayer.Location = new System.Drawing.Point(picPlayer.Location.X - 5, picPlayer.Location.Y); }
            else if (NunStil)
            { picPlayer.Location = new System.Drawing.Point(picPlayer.Location.X, picPlayer.Location.Y); }
        }
        
        void Endlap(PictureBox pic)
        {
            if (pic.Location.X < -100)
            {
                pic.Location = new System.Drawing.Point(this.Width + 100, RandomObst(200, this.Height + 200));
                intScore++;
                
            }
         }
        
        void PlayerCollision(PictureBox pic)
        {
            if(picPlayer.Bounds.IntersectsWith(pic.Bounds))
            {
                pic.Location = new System.Drawing.Point(this.Width + 100, RandomObst(200, this.Height + 200));
                LoseHealth();
                
            }
        }

        void LoseHealth()
        { intPlayerHealth = intPlayerHealth - intDamageFromEnemy;
          picPlayerHealth.Size = new Size(Convert.ToInt32(intPlayerHealth * 3.54), 62);
          Gameover();
          if (intPlayerHealth == 75)
          { wm.SetLEDs(true, true, true, false); }
          else if (intPlayerHealth == 50)
          { wm.SetLEDs(true, true, false, false); }
          else if (intPlayerHealth == 25)
          { wm.SetLEDs(true, false, false, false); }
          else if (intPlayerHealth == 0)
          { wm.SetLEDs(false, false, false, false); }

          wm.SetRumble(true);
          timRumble.Start();
        }

        void timRumble_Tick(object sender, EventArgs e)
        {

            wm.SetRumble(false);
            timRumble.Stop();
        }
        
        int RandomObst(int min, int max)
        {
            Random rdm = new Random();
            return (rdm.Next(min,max));
        }

        void Shop()
        {
            this.BackColor = Color.DimGray;
            
        }

        void Gameover()
        {
            if (intPlayerHealth < 1)
            {
                //STOP
                timFPS.Stop();
                Controls.Remove(picEnemy);
                Controls.Remove(picEnemy2);
                Controls.Remove(picEnemy3);
                Controls.Remove(picPlayer);
                Controls.Remove(picUp);
                Controls.Remove(picDown);
                Controls.Remove(picPlayerHealth);

                //GameOverscreen
                Controls.Add(picAchtergrond);
                picAchtergrond.Image = Space_Cube_Adventures.Properties.Resources.Gameoverscreen;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            { this.Close(); }
            else if (e.KeyData == Keys.P)
            { Tutorial(); }
            else if (e.KeyData == Keys.O)
            { Game(); }
            else if (e.KeyData == Keys.I)
            { Shop(); }
            

        }
    }
}
