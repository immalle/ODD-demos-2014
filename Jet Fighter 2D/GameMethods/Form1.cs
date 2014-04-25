using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI;
using WiimoteLib;

namespace JetFighter2D
{
    //main game class TO DO
    public partial class Form1 : Form
    {
        //game vars
        SoundPlayer sp;
        Wiimote wm;

        //Classes
        List<Highscore> highScores = new List<Highscore>();
        GameVars GV = new GameVars();

        //add Objects
        moveObj missile1;
        moveObj missile2;
        moveObj missile3;
        moveObj sMissile1;
        moveObj sMissile2;
        moveObj powerup1;

        public Form1()
        {
            InitializeComponent();

            //soundplayer
            Stream str = JetFighter2D.Resource2.Lost_Woods_Dubstep_Remix___Ephixa_Download_at_www;
            sp = new SoundPlayer(str);

            wm = new Wiimote();
            wm.Connect();
            wm.SetLEDs(true, false, true, false);
            wm.SetReportType(InputReport.Buttons, true);
            
            //connect Wiimote
            GV.wm.Connect();
            GV.wm.SetLEDs(true, false, true, false);

            GV.wm.WiimoteChanged += new EventHandler<WiimoteChangedEventArgs>(Wiimote_changed);

           
        }

        //start game, move missiles TO DO
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!GV.gameover)
            {
                //add speed & powerup
                if (GV.counter2 > 0 && GV.counter2 % 5 == 0)
                {
                    this.Controls.Add(powerup1.obj);
                    powerup1.obj.BringToFront();
                    GV.powerupSpawned = true;
                    powerup1.move();

                    GV.speed++;
                    GV.counter2 = 0;
                }

                //more missiles
                switch (GV.score)
                {
                    case 10:
                        if (GV.newMissile1)
                        {
                            this.Controls.Add(missile2.obj);
                            missile2.obj.BringToFront();
                            missile2.move();
                            GV.newMissile1 = false;
                        }
                        break;
                    case 15:
                        if (GV.newMissile2)
                        {
                            this.Controls.Add(missile3.obj);
                            missile3.obj.BringToFront();
                            missile3.move();
                            GV.newMissile2 = false;
                        }
                        break;
                    case 25:
                        if (GV.newMissile3)
                        {
                            this.Controls.Add(sMissile1.obj);
                            sMissile1.obj.BringToFront();
                            sMissile1.move();
                            GV.newMissile3 = false;
                        }
                        break;
                    case 40:
                        if (GV.newMissile4)
                        {
                            this.Controls.Add(sMissile2.obj);
                            sMissile2.obj.BringToFront();
                            sMissile2.move();
                            GV.newMissile4 = false;
                        }
                        break;
                    case 50:
                        //spawn boss
                        if (GV.boss)
                        {
                            GV.boss = false;
                        }
                        break;
                }

                //check collision
                CheckCollision();
            }
            else
            {
                //stop timers
                missile1.stop();
                missile2.stop();
                missile3.stop();
                sMissile1.stop();
                sMissile2.stop();
                powerup1.stop();
                timer1.Stop();

                //vanish game controls and reset locations
                this.Controls.Clear();

                //add homescreen controls
                this.Controls.Add(startButton);
                this.Controls.Add(scoreButton);
                this.Controls.Add(exitButton);
                this.Controls.Add(startPictureBox);

                startButton.BringToFront();
                scoreButton.BringToFront();
                exitButton.BringToFront();

                //reset vars
                GV.score = 0;
                GV.speed = 3;
                GV.jetSpeed = 10;
                GV.counter2 = 0;
                GV.shield = 5;
                GV.powerupSpawned = false;

                GV.newMissile1 = true;
                GV.newMissile2 = true;
                GV.newMissile3 = true;
                GV.newMissile4 = true;
                GV.boss = true;
                Cursor.Show();

                //ask playername
                //GV.playername = Microsoft.VisualBasic.Interaction.InputBox("Enter your name please.", "Name", "");

                //save score
                /*highScores.Add(new Highscore {PlayerName = GV.playername, Score = GV.score});
                using (FileStream fs = new FileStream(@"D:\temp\scores.dat", FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, highScores);
                }*/
            }
        }

        //Collision
        private void CheckCollision()
        {
            if (Collision(GV.jet, missile1.obj))//jet
            {
                //check for shield
                if (GV.shield > 0)
                {
                    GV.shield--;

                    //reset missile location
                    missile1.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                    GV.score--;
                    GV.counter2--;
                    GV.igScore.Text = "Score: " + GV.score.ToString();
                    GV.shieldLabel.Text = "Shields: " + GV.shield;
                }
                else
                {
                    GV.gameover = true;
                }
            }
            else if (Collision(GV.jet, missile2.obj))//jet
            {
                //check for shield
                if (GV.shield > 0)
                {
                    GV.shield--;

                    //reset missile location
                    missile2.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                    GV.score--;
                    GV.counter2--;
                    GV.igScore.Text = "Score: " + GV.score.ToString();
                    GV.shieldLabel.Text = "Shields: " + GV.shield;
                }
                else
                {
                    GV.gameover = true;
                }
            }
            else if (Collision(GV.jet, missile3.obj))//jet
            {
                //check for shield
                if (GV.shield > 0)
                {
                    GV.shield--;

                    //reset missile location
                    missile3.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                    GV.score--;
                    GV.counter2--;
                    GV.igScore.Text = "Score: " + GV.score.ToString();
                    GV.shieldLabel.Text = "Shields: " + GV.shield;
                }
                else
                {
                    GV.gameover = true;
                }
            }
            else if (Collision(GV.jet, sMissile1.obj))//jet
            {
                //check for shield
                if (GV.shield > 0)
                {
                    GV.shield--;

                    //reset missile location
                    sMissile1.obj.Location = new System.Drawing.Point(1, GV.ranGen.Next(1, this.Height - 1));
                    GV.score--;
                    GV.counter2--;
                    GV.igScore.Text = "Score: " + GV.score.ToString();
                    GV.shieldLabel.Text = "Shields: " + GV.shield;
                }
                else
                {
                    GV.gameover = true;
                }
            }
            else if (Collision(GV.jet, sMissile2.obj))//jet
            {
                //check for shield
                if (GV.shield > 0)
                {
                    GV.shield--;

                    //reset missile location
                    sMissile2.obj.Location = new System.Drawing.Point(1, GV.ranGen.Next(1, this.Height - 1));
                    GV.score--;
                    GV.counter2--;
                    GV.igScore.Text = "Score: " + GV.score.ToString();
                    GV.shieldLabel.Text = "Shields: " + GV.shield;
                }
                else
                {
                    GV.gameover = true;
                }
            }

            else if (CollisionBorder(GV.jet))
            {
                GV.gameover = true;
            }
            else if (GV.powerupSpawned)//powerup
            {
                if (CollisionPowerup(GV.jet, powerup1.obj))
                {

                    //choose random powerup
                    switch (GV.ranGen.Next(1, 3))
                    {
                        case 1:
                            GV.shield += 1;
                            break;
                        case 2:
                            GV.shield += 2;
                            break;
                    }

                    GV.shieldLabel.Text = "Shields: " + GV.shield;

                    powerup1.stop();
                    this.Controls.Remove(powerup1.obj);
                    GV.powerupSpawned = false;

                    powerup1.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                }
                else if (powerup1.obj.Location.Y >= this.Height)
                {
                    powerup1.stop();
                    this.Controls.Remove(powerup1.obj);
                    GV.powerupSpawned = false;

                    powerup1.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                }
            }

            //side
            if (sMissile1.obj.Location.X >= this.Width)
            {
                sMissile1.obj.Location = new System.Drawing.Point(1, GV.ranGen.Next(1, this.Height - 1));
                GV.score++;
                GV.counter2++;
                GV.igScore.Text = "Score: " + GV.score.ToString();
            }

            if (sMissile2.obj.Location.X >= this.Width)
            {
                sMissile2.obj.Location = new System.Drawing.Point(1, GV.ranGen.Next(1, this.Height - 1));
                GV.score++;
                GV.counter2++;
                GV.igScore.Text = "Score: " + GV.score.ToString();
            }

            //top
            if (missile1.obj.Location.Y >= this.Height)
            {
                missile1.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.score++;
                GV.counter2++;
                GV.igScore.Text = "Score: " + GV.score.ToString();
            }

            if (missile2.obj.Location.Y >= this.Height)
            {
                missile2.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.score++;
                GV.counter2++;
                GV.igScore.Text = "Score: " + GV.score.ToString();
            }

            if (missile3.obj.Location.Y >= this.Height)
            {
                missile3.obj.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.score++;
                GV.counter2++;
                GV.igScore.Text = "Score: " + GV.score.ToString();
            }
        }

        //load
        private void Form1_Load(object sender, EventArgs e)
        {
            //start soundsplayer
            sp.PlayLooping();

            //load Highscores
            if (!File.Exists(@"D:\temp\scores.dat"))
            {
                //add default scores
                highScores.Add(new Highscore { PlayerName = "John", Score = 100 });
                highScores.Add(new Highscore { PlayerName = "Clark", Score = 55 });
                highScores.Add(new Highscore { PlayerName = "Charles", Score = 92 });
                highScores.Add(new Highscore { PlayerName = "Jason", Score = 72 });
                highScores.Add(new Highscore { PlayerName = "Mike", Score = 1 });

                /*using (FileStream fs = new FileStream(@"D:\temp\scores.dat", FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, highScores);
                }*/
            }
            else
            {
                using (FileStream fs = new FileStream(@"C:\temp\scores.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    highScores = (List<Highscore>)formatter.Deserialize(fs);
                }
            }

            //set properties jet
            GV.CreateJet(this.Width / 2, this.Height - 200);

            //set properties countdown timer
            GV.setPropertiescdTimer();
            GV.cdTimer.Tick += new EventHandler(cdTimer_Tick);

            //Objects
            missile1 = new moveObj(this.Height, this.Width, false, true, false, GV.ranGen.Next(4, 10));
            missile2 = new moveObj(this.Height, this.Width, false, true, false, GV.ranGen.Next(4, 10));
            missile3 = new moveObj(this.Height, this.Width, false, true, false, GV.ranGen.Next(4, 10));
            sMissile1 = new moveObj(this.Height, this.Width, true, false, false, GV.ranGen.Next(4, 10));
            sMissile2 = new moveObj(this.Height, this.Width, true, false, false, GV.ranGen.Next(4, 10));
            powerup1 = new moveObj(this.Height, this.Width, false, false, true, GV.ranGen.Next(4, 10));

            GV.formHeight = this.Height;
            GV.formWidth = this.Width;
        }

        //Jet controls event
        private void Wiimote_changed(Object sender, EventArgs e)
        {
            int x = GV.jet.Location.X;
            int y = GV.jet.Location.Y;

            if (wm.WiimoteState.ButtonState.Left)
                x -= GV.jetSpeed;

            if (wm.WiimoteState.ButtonState.Right)
                x += GV.jetSpeed;

            if (wm.WiimoteState.ButtonState.Down)
                y += GV.jetSpeed;

            if (wm.WiimoteState.ButtonState.Up)
                y -= GV.jetSpeed;

            GV.jet.Location = new System.Drawing.Point(x, y);
        }

        // Countdown timer
        private void cdTimer_Tick(Object sender, EventArgs e)
        {
            this.Controls.Add(GV.cdLabel);
            GV.cdLabel.Text = (GV.counter - 1).ToString();
            GV.counter--;

            if (GV.counter == 0)
            {
                GV.counter = 4;

                //start game
                GV.cdTimer.Stop();
                this.Controls.Remove(GV.cdLabel);

                timer1.Start();

                this.Controls.Add(missile1.obj);
                missile1.obj.BringToFront();
                missile1.move();

                this.ActiveControl = GV.jet;
            }
        }

        //collision functions
        private bool Collision(PictureBox jet, PictureBox missile)
        {
            if (jet.Location.X + (jet.Width - 10) < missile.Location.X)
                return false;
            if (missile.Location.X + (missile.Width - 10) < jet.Location.X)
                return false;
            if (jet.Location.Y + jet.Height < missile.Location.Y)
                return false;
            if (missile.Location.Y + missile.Height < jet.Location.Y)
                return false;
            return true;
        }

        private bool CollisionBorder(PictureBox jet)
        {
            if (jet.Bounds.IntersectsWith(this.Bounds))
                return false;
            return true;
        }

        private bool CollisionPowerup(PictureBox jet, PictureBox powerup)
        {
            if (jet.Bounds.IntersectsWith(powerup.Bounds))
                return true;
            return false;
        }

        //Click events
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cursor.Hide();

            //vanish startscreen controls
            this.Controls.Clear();

            //add field
            //this.BackgroundImage = JetFighter2D.Resource13.Sky2;
            this.BackColor = Color.DeepSkyBlue;

            //add score label
            GV.igScore.Location = new System.Drawing.Point(15, 15);
            GV.igScore.AutoSize = true;
            GV.igScore.TextAlign = ContentAlignment.MiddleLeft;
            GV.igScore.ForeColor = Color.OrangeRed;
            GV.igScore.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GV.igScore.Text = "Score: " + GV.score.ToString();
            this.Controls.Add(GV.igScore);

            //add shieldlabel
            GV.shieldLabel.Location = new System.Drawing.Point(15, 50);
            GV.shieldLabel.AutoSize = true;
            GV.shieldLabel.TextAlign = ContentAlignment.MiddleCenter;
            GV.shieldLabel.ForeColor = Color.OrangeRed;
            GV.shieldLabel.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GV.shieldLabel.Text = "Shields: 5";
            this.Controls.Add(GV.shieldLabel);

            //add jet
            GV.jet.Location = new System.Drawing.Point(GV.ranGen.Next(1, this.Width), this.Height - 200);
            this.Controls.Add(GV.jet);
            GV.jet.BringToFront();

            wm.WiimoteChanged += new EventHandler<WiimoteChangedEventArgs>(Wiimote_changed);

            //set gameover to false;

            GV.gameover = false;

            //start countdown
            GV.cdLabel.Size = new System.Drawing.Size(400, 100);
            GV.cdLabel.TextAlign = ContentAlignment.MiddleCenter;
            GV.cdLabel.ForeColor = Color.OrangeRed;
            GV.cdLabel.Font = new Font("Microsoft Sans Serif", 72F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GV.cdLabel.Location = new System.Drawing.Point((this.Width - GV.cdLabel.Width) / 2, (this.Height - GV.cdLabel.Height) / 2);
            GV.cdLabel.Text = "Ready?";
            this.Controls.Add(GV.cdLabel);
            GV.cdLabel.BringToFront();

            GV.cdTimer.Start();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //new form with docked label
            Form scoreboard = new Form();
            GV.sbLabel.Dock = DockStyle.Fill;
            scoreboard.Controls.Add(GV.sbLabel);

            scoreboard.ShowDialog();

            foreach (Highscore score in highScores)
            {
                GV.sbLabel.Text = String.Format("{0}: {1} System.Drawing.points", score.PlayerName, score.Score + Environment.NewLine);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }

    //highscore class NOT ACTIVE
    [Serializable]
    public class Highscore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }

    //GameVars class
    public class GameVars
    {
        //constructor
        public GameVars()
        {
            
        }

        //vars
        public bool gameover = false;
        public bool powerupSpawned = false;
        public bool newMissile1 = true;
        public bool newMissile2 = true;
        public bool newMissile3 = true;
        public bool newMissile4 = true;
        public bool boss = true;
        public int counter = 4;
        public int score = 0;
        public int shield = 5;
        public int speed = 3;
        public int jetSpeed = 10;
        public int counter2 = 0;
        public string playername = "player1";

        //properties
        public int formHeight { get; set; }
        public int formWidth { get; set; }

        //Objects
        public Random ranGen = new Random();
        public Label cdLabel = new Label();
        public Label igScore = new Label();
        public Label sbLabel = new Label();
        public Label shieldLabel = new Label();
        public Timer cdTimer = new Timer();
        public Wiimote wm = new Wiimote();

        public PictureBox jet;

        //countdown timer
        public void setPropertiescdTimer()
        {
            cdTimer.Interval = 1000;
        }

        //jet
        private PictureBox Jet(int x, int y)
        {
            PictureBox jet = new PictureBox();
            jet.Size = new Size(140, 170);
            jet.Image = JetFighter2D.Resource6.FighterJetFixedHitbox;
            jet.SizeMode = PictureBoxSizeMode.Zoom;
            jet.Location = new System.Drawing.Point(x, y);

            return jet;
        }

        //create jet
        public void CreateJet(int x, int y)
        {
            jet = Jet(x, y);
        }
    }

    //moveObj class
    //INCLUDES: powerup, missileTop, missileSide
    public class moveObj
    {
        GameVars GV = new GameVars();

        //vars
        public PictureBox obj = new PictureBox();

        Random ranGen = new Random();
        Timer objTimer = new Timer();

        int tInterval;
        int formheight;
        int formwidth;
        bool x;
        bool y;

        //constructor
        public moveObj(int height, int width, bool side, bool top, bool powerup, int interval)
        {
            tInterval = interval;
            formheight = height;
            formwidth = width;
            x = side;
            y = top;

            if (side || top || powerup)
            {
                if (side)
                {
                    obj.Size = new Size(100, 50);
                    obj.Image = JetFighter2D.Resource12.sideMissile;
                    obj.SizeMode = PictureBoxSizeMode.Zoom;
                    obj.Location = new System.Drawing.Point(1, ranGen.Next(1, height));
                }
                else if (top)
                {
                    obj.Size = new Size(50, 100);
                    obj.Image = JetFighter2D.Resource7.missileFixedHitbox;
                    obj.SizeMode = PictureBoxSizeMode.Zoom;
                    obj.Location = new System.Drawing.Point(ranGen.Next(1, width), 1);//min max value exception
                }
                else
                {
                    obj.Size = new Size(50, 50);
                    obj.Image = JetFighter2D.Resource5.powerup;
                    obj.SizeMode = PictureBoxSizeMode.Zoom;
                    obj.Location = new System.Drawing.Point(ranGen.Next(1, width), 1);
                }
            }
        }

        //move obj
        public void move()
        {
            objTimer.Tick += new EventHandler(objTimer_Tick);
            objTimer.Interval = tInterval;
            objTimer.Start();
        }

        //stop obj
        public void stop()
        {
            objTimer.Stop();

            if (x)
            {
                obj.Location = new System.Drawing.Point(1, ranGen.Next(1, formheight));
            }
            else
            {
                obj.Location = new System.Drawing.Point(ranGen.Next(1, formwidth), 1);
            }
        }

        //timer to move
        private void objTimer_Tick(Object sender, EventArgs e)
        {
            if (x)
            {
                moveToSide();
            }
            else if (y)
            {
                moveToBottom();
            }
            else
            {
                obj.Location = new System.Drawing.Point(obj.Location.X, obj.Location.Y + 1);
            }
        }

        //move functions
        private void moveToBottom()
        {
            obj.Location = new System.Drawing.Point(obj.Location.X, obj.Location.Y + GV.speed);
        }

        private void moveToSide()
        {
            obj.Location = new System.Drawing.Point(obj.Location.X + GV.speed, obj.Location.Y);
        }
    }
}
