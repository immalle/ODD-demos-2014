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
using System.IO;

namespace Space_Cube_Adventures
{
    public partial class Form1 : Form
    {
        //INTS
        int intPlayerHealth = 100;
        int intDamageFromEnemy = 25;
        int intPlayerSize = 75;
        int intEnemySize = 50;
        int intSpeed = 15;
        int intScore = 0;
        int intScorePS = 1;
        int intPowerupchance = 45;
        int intPowerupWaarde = 1;
        int intPowerupVolgorde = 1;
        int intGunmode = 0;
        
        //PICTURBOXES
        PictureBox picAchtergrond;
        PictureBox picDown;
        PictureBox picUp;
        PictureBox picPlayer;
        PictureBox picPlayerHealth;
        PictureBox picEnemy;
        PictureBox picEnemy2;
        PictureBox picEnemy3;
        PictureBox picLazer;
        PictureBox picLazer2;
        PictureBox picLazer3;
        PictureBox picPowerup;
        
        
        //WIIMOTE
        Wiimote wm = new Wiimote();
        

        //BOOLS
        bool boolShot;
            //MOVEMENT
        bool NunLinks;
        bool NunRechts;
        bool NunOnder;
        bool NunBoven;
        bool NunStil;
        bool NunShoot;
            //BUTTONS
        bool NunZ;
            //POWERUPS
        bool boolPup;
        bool boolPup2;
        bool boolPup3;
        bool boolPupdown;
        bool boolUltramode;
            //BEGIN
        bool boolstart;

        //TIMER
        Timer timFPS;
        Timer timTutorial;
        Timer timRumble;
        Timer timSpeed;

        //LABELS
        Label lblScore;

        //STRINGS
        string Highscore;


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

            boolstart = true;
            Cursor.Hide();
        }

        void Tutorial() 
        {
            //RESET
            boolstart = false;

            ///INTS
            intPlayerHealth = 100;
            intDamageFromEnemy = 0;
            intPlayerSize = 75;
            intEnemySize = 50;
            intSpeed = 30;
            intScore = 0;
            intScorePS = 1;
            intPowerupchance = 15;

            picAchtergrond.Image = Space_Cube_Adventures.Properties.Resources.Tutorial;
            this.BackColor = Color.Black;

            timTutorial = new Timer();
            timTutorial.Interval = 2000;
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
            
            //SHOOT
            if (boolShot)
            {   
                switch(intGunmode)
                {
                    case 0: 
                        break;
                    case 1: picLazer.Location = new System.Drawing.Point(picLazer.Location.X + 35, picLazer.Location.Y);
                        break;
                    case 2: picLazer.Location = new System.Drawing.Point(picLazer.Location.X + 35, picLazer.Location.Y);
                            picLazer2.Location = new System.Drawing.Point(picLazer2.Location.X + 35, picLazer2.Location.Y);
                        break;
                    case 3: picLazer.Location = new System.Drawing.Point(picLazer.Location.X + 35, picLazer.Location.Y);
                            picLazer2.Location = new System.Drawing.Point(picLazer2.Location.X + 35, picLazer2.Location.Y);
                            picLazer3.Location = new System.Drawing.Point(picLazer3.Location.X + 35, picLazer3.Location.Y);
                        break;

                }
                
                
            }

            //POWERUPS
            PowerupMovement(picPowerup, ref boolPup);
            PowerupMovement(picPowerup, ref boolPup2);
            PowerupMovement(picPowerup, ref boolPup3);

            //MOVE PLAYER
            PlayerMovement();
            
            //SCORE
            intScore = intScore + intScorePS;
            lblScore.Text = (intScore/100).ToString();
            
            //COURSE RESET
            Endlap(picEnemy);
            Endlap(picEnemy2);
            Endlap(picEnemy3);

            //COLLISION
            PlayerCollision(picEnemy);
            PlayerCollision(picEnemy2);
            PlayerCollision(picEnemy3);

            //SHOOT
            Shoot();
        }

        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {
            WiimoteState ws = e.WiimoteState;
            NunShoot = ws.ButtonState.B;
            
           
            
            if (ws.ExtensionType == ExtensionType.Nunchuk)
            {
                if (boolstart && ws.NunchukState.Z)
                {
                    Tutorial();
                    boolstart = false;
                }
                
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

            if(picPlayer.Bounds.IntersectsWith(picUp.Bounds))
            { picPlayer.Location = new System.Drawing.Point(picPlayer.Location.X, this.Height - intPlayerSize - picDown.Height - 2); }
            
            if(picPlayer.Bounds.IntersectsWith(picDown.Bounds))
            { picPlayer.Location = new System.Drawing.Point(picPlayer.Location.X, 114); }
        }
        
        void Endlap(PictureBox pic)
        {
            if (pic.Location.X < -100)
            {
                pic.Location = new System.Drawing.Point(this.Width + 100, RandomObst(113, this.Height - 112));
                intScore++;
                Powerup();
            }
         }

        void PewEndlap(PictureBox pic)
        {
            if (pic.Location.X > this.Width)
            {
                boolShot = false;
                Controls.Remove(picLazer);
                Controls.Remove(picLazer2);
                Controls.Remove(picLazer3);
            }
        }

        int PowerupChance(int max)
        {
            Random r = new Random();
            return(r.Next(0,max));
        }

        void Powerup()
        {
            if (PowerupChance(intPowerupchance) == 1)
            {   Random r = new Random();
               switch(intPowerupVolgorde)
                {
                    
                   
                   case 1: 
                        //PUNTEN
                        if (!boolPup && !boolPup2 && !boolPup3)
                        {
                            picPowerup = new PictureBox();
                            picPowerup.Image = Space_Cube_Adventures.Properties.Resources.Powerup2;
                            picPowerup.Location = new System.Drawing.Point(this.Width + 50, r.Next(115, this.Height - 250));
                            picPowerup.Size = new Size(50, 50);
                            Controls.Add(picPowerup);
                            boolPup = true;
                            intPowerupWaarde = 1;
                            intPowerupVolgorde++;
                            
                        }
                        break;
                    case 2:
                        //WEAPON
                        if (!boolPup && !boolPup2 && !boolPup3)
                        {
                            picPowerup = new PictureBox();
                            picPowerup.Image = Space_Cube_Adventures.Properties.Resources.Powerup1;
                            picPowerup.Location = new System.Drawing.Point(this.Width + 50, r.Next(115, this.Height - 250));
                            picPowerup.Size = new Size(50, 50);
                            Controls.Add(picPowerup);
                            boolPup2 = true;
                            intPowerupWaarde = 2;
                            intPowerupVolgorde = 1;
                        }
                        break;
                    
                }
                
            }
        }

        void PowerupMovement(PictureBox pic, ref bool pup)
        {
            if (pup)
            {
                PowerupCollision(picPowerup, ref boolPup, ref boolPup2, ref boolPup3);
                if (boolPupdown)
                {
                    pic.Location = new System.Drawing.Point(pic.Location.X - 5, pic.Location.Y + 3);
                    if (pic.Location.Y > 800)
                    { boolPupdown = false; }
                }
                else
                {
                    
                    pic.Location = new System.Drawing.Point(pic.Location.X - 5, pic.Location.Y - 2);
                    if (pic.Location.Y < 300)
                    { boolPupdown = true; }
                }

            }

            
            
            if(pup && pic.Location.X < -50)
            { Controls.Remove(pic);
                pup = false;
            }
        }

        void PowerupCollision(PictureBox pic, ref bool pup1, ref bool pup2, ref bool pup3)
        {
            //POINTS
            if(picPlayer.Bounds.IntersectsWith(pic.Bounds))
            {switch(intPowerupWaarde)
                {
                    case 1: //PUNTEN
                        intScore = intScore + 25 + intSpeed;
                            pup1 = false;
                            Controls.Remove(pic);
                            break;
                    case 2: //GUNUPGRADE
                            intGunmode++;
                            switch (intGunmode)
                                {
                                    case 1:
                                            picPlayer.Size = new System.Drawing.Size(100, 150);
                                            picPlayer.Image = Space_Cube_Adventures.Properties.Resources.Lazer1;
                                            break;
                                    case 2:
                                            picPlayer.Image = Space_Cube_Adventures.Properties.Resources.Lazer2;
                                            break;
                                    case 3:
                                            picPlayer.Image = Space_Cube_Adventures.Properties.Resources.Lazer3;
                                            break;
                                }
                            intScore = intScore + 15;
                            pup2 = false;
                            Controls.Remove(pic);
                            break;
                    case 3: //ULTRAMODE
                            //intScore = intScore + intPowerupPoints;
                            //pup3 = false;
                            //Controls.Remove(pic);
                            break;
            }
        }
            
        }

        void PlayerCollision(PictureBox pic)
        {
            if(picPlayer.Bounds.IntersectsWith(pic.Bounds))
            {
                pic.Location = new System.Drawing.Point(this.Width + 100, RandomObst(200, this.Height + 200));
                LoseHealth();
                
            }
            if (boolShot)
            {
                if (picLazer.Bounds.IntersectsWith(pic.Bounds))
                {
                    pic.Location = new System.Drawing.Point(this.Width + 100, RandomObst(200, this.Height + 200));
                    intScore = intScore + 250;
                }
            }
        }

        void Shoot()
        {
            if (NunShoot && !boolShot)
            
            {
                switch(intGunmode)
                {
                    case 0: break;
                    case 1: 
                            picLazer = new PictureBox();
                            picLazer.Location = new System.Drawing.Point(picPlayer.Location.X + (intPlayerSize / 2), picPlayer.Location.Y + (intPlayerSize / 2) + 28);
                            picLazer.Image = Space_Cube_Adventures.Properties.Resources.fireball;
                            picLazer.Size = new System.Drawing.Size(30, 21);
                            picLazer.SizeMode = PictureBoxSizeMode.Zoom;
                            Controls.Add(picLazer);
                            boolShot = true;
                            break;
                    case 2:
                            
                            picLazer = new PictureBox();
                            picLazer.Location = new System.Drawing.Point(picPlayer.Location.X + (intPlayerSize / 2), picPlayer.Location.Y + (intPlayerSize / 2) + 15);
                            picLazer.Image = Space_Cube_Adventures.Properties.Resources.fireball;
                            picLazer.Size = new System.Drawing.Size(30, 21);
                            picLazer.SizeMode = PictureBoxSizeMode.Zoom;
                            picLazer2 = new PictureBox();
                            picLazer2.Location = new System.Drawing.Point(picPlayer.Location.X + (intPlayerSize / 2), picPlayer.Location.Y + (intPlayerSize / 2) + 30);
                            picLazer2.Image = Space_Cube_Adventures.Properties.Resources.fireball;
                            picLazer2.Size = new System.Drawing.Size(30, 21);
                            picLazer2.SizeMode = PictureBoxSizeMode.Zoom;
                            Controls.Add(picLazer2);
                            Controls.Add(picLazer);
                            boolShot = true;
                            break;

                    case 3:
                            picLazer = new PictureBox();
                            picLazer.Location = new System.Drawing.Point(picPlayer.Location.X + (intPlayerSize / 2), picPlayer.Location.Y + (intPlayerSize / 2) + 10);
                            picLazer.Image = Space_Cube_Adventures.Properties.Resources.fireball;
                            picLazer.Size = new System.Drawing.Size(30, 21);
                            picLazer.SizeMode = PictureBoxSizeMode.Zoom;
                            picLazer2 = new PictureBox();
                            picLazer2.Location = new System.Drawing.Point(picPlayer.Location.X + (intPlayerSize / 2), picPlayer.Location.Y + (intPlayerSize / 2) + 20);
                            picLazer2.Image = Space_Cube_Adventures.Properties.Resources.fireball;
                            picLazer2.Size = new System.Drawing.Size(30, 21);
                            picLazer2.SizeMode = PictureBoxSizeMode.Zoom;
                            picLazer3 = new PictureBox();
                            picLazer3.Location = new System.Drawing.Point(picPlayer.Location.X + (intPlayerSize / 2), picPlayer.Location.Y + (intPlayerSize / 2) + 30);
                            picLazer3.Image = Space_Cube_Adventures.Properties.Resources.fireball;
                            picLazer3.Size = new System.Drawing.Size(30, 21);
                            picLazer3.SizeMode = PictureBoxSizeMode.Zoom;
                            Controls.Add(picLazer3);
                            Controls.Add(picLazer2);
                            Controls.Add(picLazer);
                            boolShot = true;
                            break;
                }
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
                Controls.Remove(picLazer);
                Controls.Remove(lblScore);

                //GameOverscreen
                Controls.Add(picAchtergrond);
                picAchtergrond.Image = Space_Cube_Adventures.Properties.Resources.Gameoverscreen;

                //Highscores
                InputBox("Highscore", "Voer je naam in", ref Highscore);
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\5I\Laurens Theunis\test.txt", true);
                string ScoreNaam = Highscore + " " + (intScore / 100) ;
                file.WriteLine(ScoreNaam);
                file.Close();

            }

        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "Enter";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            { this.Close(); }
            if (e.KeyData == Keys.P)
            { Tutorial(); }
            if (e.KeyData == Keys.B)
            { Shoot(); }
            
            

        }
    }
}
