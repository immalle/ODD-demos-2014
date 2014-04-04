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
//using WiimoteLib;

namespace GameMethods
{
    //main game class TEST sMissiles
    public partial class Form1 : Form
    {
        //game vars
        SoundPlayer sp;
        SoundPlayer sp2;
        bool check = true;

        //Highscore not active
        List<Highscore> highScores = new List<Highscore>();

        //Powerups
        Powerups PU = new Powerups(GameMethods.Resource5.powerup);

        //GameVars
        GameVars GV = new GameVars();

        //MoreMissiles
        MoreMissiles MM = new MoreMissiles();

        public Form1()
        {
            InitializeComponent();

            //soundplayer
            Stream str = GameMethods.Resource2.Lost_Woods_Dubstep_Remix___Ephixa_Download_at_www;
            sp = new SoundPlayer(str);

            Stream str2 = GameMethods.Resource10.crash;
            sp2 = new SoundPlayer(str2);

            PU.height = this.Height;
            MM.height = this.Height;
            MM.width = this.Width;
        }

        //start game, move missiles
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!GV.gameover)
            {

                //if true, Add new missile to form
                if (check)
                {
                    this.Controls.Add(GV.missile1);
                    GV.missile1.BringToFront();
                    check = false;
                }

                //move
                GV.missile1.Location = new Point(GV.missile1.Location.X, GV.missile1.Location.Y + GV.speed);

                //if y > form height, reset missile location
                if (GV.missile1.Location.Y >= this.Height)
                {
                    GV.missile1.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                    GV.score++;
                    GV.counter2++;
                    GV.igScore.Text = GV.score.ToString();
                }

                //add speed + powerup + more missiles
                if (GV.counter2 > 0 && GV.counter2 % 5 == 0)//if true, process once, then  wait for score++
                {
                    GV.counter2 = 0;
                    GV.speed++;
                    GV.powerupSpawned = true;
                    this.Controls.Add(PU.addPowerup(this.Width));
                    PU.powerup.BringToFront();
                    PU.movePowerup();

                    //more missiles
                    switch (GV.score)
                    {
                        case 10:
                            this.Controls.Add(GV.missile2);
                            GV.missile2.BringToFront();
                            GV.missile2spawned = true;
                            timer2.Start();
                            break;
                        case 15:
                            //more missiles side TEST
                            GV.sideMissileSpawned = true;
                            this.Controls.Add(GV.sideMissile);
                            GV.sideMissile.BringToFront();
                            MM.moveSideMissile();

                            /*this.Controls.Add(GV.missile3);
                            GV.missile3.BringToFront();
                            GV.missile3spawned = true;
                            timer3.Start();*/
                            break;
                        case 20:
                            /*this.Controls.Add(GV.missile4);
                            GV.missile4.BringToFront();
                            GV.missile4spawned = true;
                            timer4.Start();*/
                            break;
                        case 25:
                            /*this.Controls.Add(GV.missile5);
                            GV.missile5.BringToFront();
                            GV.missile5spawned = true;
                            timer5.Start();*/
                            break;
                    }
                }
                    
                //check collision
                CheckCollision();
            }
            else
            {
                //stop timers
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                timer5.Stop();
                MM.moveMissile.Stop();

                //vanish game controls and reset missile1 location
                GV.missile1.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.missile2.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.missile3.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.missile4.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.missile5.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);

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
                check = true;
                GV.missile2spawned = false;
                GV.missile3spawned = false;
                GV.missile4spawned = false;
                GV.missile5spawned = false;
                GV.sideMissileSpawned = false;
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

                GV.score = 0;
                GV.speed = 3;
                GV.counter2 = 0;
            }
        }

        //Collision OK
        private void CheckCollision()
        {
            if (Collision(GV.jet, GV.missile1))
            {
                //check for shield
                if (GV.shield > 0)
                {
                    GV.shield--;
                }
                else
                {
                    GV.gameover = true;
                }
            }
            else if (GV.missile2spawned)
            {
                if (Collision(GV.jet, GV.missile2))
                {
                    //check for shield
                    if (GV.shield > 0)
                    {
                        GV.shield--;
                    }
                    else
                    {
                        GV.gameover = true;
                    }
                }
            }
            else if (GV.missile3spawned)
            {
                if (Collision(GV.jet, GV.missile3))
                {
                    //check for shield
                    if (GV.shield > 0)
                    {
                        GV.shield--;
                    }
                    else
                    {
                        GV.gameover = true;
                    }
                }
            }
            else if (GV.missile4spawned)
            {
                if (Collision(GV.jet, GV.missile4))
                {
                    //check for shield
                    if (GV.shield > 0)
                    {
                        GV.shield--;
                    }
                    else
                    {
                        GV.gameover = true;
                    }
                }
            }
            else if (GV.missile5spawned)
            {
                if (Collision(GV.jet, GV.missile5))
                {
                    //check for shield
                    if (GV.shield > 0)
                    {
                        GV.shield--;
                    }
                    else
                    {
                        GV.gameover = true;
                    }
                }
            }
            else if (GV.sideMissileSpawned)
            {
                if (Collision(GV.jet, GV.sideMissile))
                {
                    MM.moveMissile.Stop();
                    GV.gameover = true;
                    GV.sideMissileSpawned = false;
                }
            }
            else if (CollisionBorder(GV.jet))
            {
                GV.gameover = true;
            }
            else if (GV.powerupSpawned)
            {
                if (CollisionPowerup(GV.jet, PU.powerup))
                {
                    PU.usePowerup();
                    this.Controls.Remove(PU.powerup);
                    PU.movePowerupTimer.Stop();
                    GV.powerupSpawned = false;
                }
                else if (PU.powerup.Location.Y >= this.Height)
                {
                    PU.movePowerupTimer.Stop();
                    this.Controls.Remove(PU.powerup);
                    GV.powerupSpawned = false;
                }
            }
        }

        //load OK
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

            //set properties jet, missiles
            GV.CreateJet(this.Width / 2, this.Height - 200);
            GV.jet.PreviewKeyDown += new PreviewKeyDownEventHandler(pbJet_PreviewKeyDown);

            GV.CreateMissile(ref GV.missile1, this.Width);
            GV.CreateMissile(ref GV.missile2, this.Width);
            GV.CreateMissile(ref GV.missile3, this.Width);
            GV.CreateMissile(ref GV.missile4, this.Width);
            GV.CreateMissile(ref GV.missile5, this.Width);

            GV.CreateSideMissile(ref GV.sideMissile, this.Height);

            //set properties countdown timer
            GV.setPropertiescdTimer();
            GV.cdTimer.Tick += new EventHandler(cdTimer_Tick);
        }

        //Jet controls event OK
        private void pbJet_PreviewKeyDown(Object sender, PreviewKeyDownEventArgs e)
        {
            PictureBox pbJet = sender as PictureBox;

            int x = pbJet.Location.X;
            int y = pbJet.Location.Y;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    x -= GV.jetSpeed;
                    break;
                case Keys.Right:
                    x += GV.jetSpeed;
                    break;
                case Keys.Up:
                    y -= GV.jetSpeed;
                    break;
                case Keys.Down:
                    y += GV.jetSpeed;
                    break;
            }

            pbJet.Location = new Point(x, y);
        }

        // Countdown timer OK
        private void cdTimer_Tick(Object sender, EventArgs e)
        {
            this.Controls.Add(GV.cdLabel);
            GV.cdLabel.Text = (GV.counter -1).ToString();
            GV.counter--;

            if(GV.counter == 0)
            {
                GV.counter = 4;

                //start game
                GV.cdTimer.Stop();
                this.Controls.Remove(GV.cdLabel);

                timer1.Start();
                this.ActiveControl = GV.jet;
            }
        }

        //collision missile OK
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

        //collision detection border OK
        private bool CollisionBorder(PictureBox jet)
        {
            if (jet.Bounds.IntersectsWith(this.Bounds))
                return false;
            return true;
        }

        //collision Powerup OK
        private bool CollisionPowerup(PictureBox jet, PictureBox powerup)
        {
            if (jet.Bounds.IntersectsWith(powerup.Bounds))
                return true;
            return false;
        }

        //Play! OK //add igscorelabel prop
        private void startButton_Click(object sender, EventArgs e)
        {
            Cursor.Hide();

            //vanish startscreen controls
            this.Controls.Clear();

            //add field
            this.BackColor = Color.DeepSkyBlue;

            //add score label
            GV.igScore.Location = new Point(15, 15);
            GV.igScore.AutoSize = true;
            GV.igScore.TextAlign = ContentAlignment.MiddleLeft;
            GV.igScore.ForeColor = Color.OrangeRed;
            GV.igScore.Font = new Font("Microsoft Sans Serif", 72F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GV.igScore.Text = GV.score.ToString();
            this.Controls.Add(GV.igScore);

            //add jet
            GV.jet.Location = new Point(GV.ranGen.Next(1, this.Width), this.Height - 200);
            this.Controls.Add(GV.jet);
            GV.jet.BringToFront();

            //start countdown
            GV.cdLabel.Size = new System.Drawing.Size(400, 100);
            GV.cdLabel.TextAlign = ContentAlignment.MiddleCenter;
            GV.cdLabel.ForeColor = Color.OrangeRed;
            GV.cdLabel.Font = new Font("Microsoft Sans Serif", 72F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GV.cdLabel.Location = new Point((this.Width - GV.cdLabel.Width) /2, (this.Height - GV.cdLabel.Height) /2);
            GV.cdLabel.Text = "Ready?";
            this.Controls.Add(GV.cdLabel);
            GV.cdLabel.BringToFront();

            GV.gameover = false;
            GV.cdTimer.Start();
        }

        //scoreboard OK
        private void scoreButton_Click(object sender, EventArgs e)
        {
            //new form with docked label
            Form scoreboard = new Form();
            GV.sbLabel.Dock = DockStyle.Fill;
            scoreboard.Controls.Add(GV.sbLabel);

            scoreboard.ShowDialog();

            foreach (Highscore score in highScores)
            {
                GV.sbLabel.Text = String.Format("{0}: {1} points", score.PlayerName, score.Score + Environment.NewLine);
            }
        }

        //Quit OK
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //missile2
        private void timer2_Tick(object sender, EventArgs e)
        {
            //move
            GV.missile2.Location = new Point(GV.missile2.Location.X, GV.missile2.Location.Y + (GV.speed + 1));

            //if y > form height, reset missile location
            if (GV.missile2.Location.Y >= this.Height)
            {
                GV.missile2.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.score++;
                GV.igScore.Text = GV.score.ToString();
            }
        }

        //missile3
        private void timer3_Tick(object sender, EventArgs e)
        {
            //move
            GV.missile3.Location = new Point(GV.missile3.Location.X, GV.missile3.Location.Y + (GV.speed - 1));

            //if y > form height, reset missile location
            if (GV.missile3.Location.Y >= this.Height)
            {
                GV.missile3.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.score++;
                GV.igScore.Text = GV.score.ToString();
            }
        }

        //missile4
        private void timer4_Tick(object sender, EventArgs e)
        {
            //move
            GV.missile4.Location = new Point(GV.missile4.Location.X, GV.missile4.Location.Y + (GV.speed + 2));

            //if y > form height, reset missile location
            if (GV.missile4.Location.Y >= this.Height)
            {
                GV.missile4.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.score++;
                GV.igScore.Text = GV.score.ToString();
            }
        }

        //missile5
        private void timer5_Tick(object sender, EventArgs e)
        {
            //move
            GV.missile5.Location = new Point(GV.missile5.Location.X, GV.missile5.Location.Y + (GV.speed - 3));

            //if y > form height, reset missile location
            if (GV.missile5.Location.Y >= this.Height)
            {
                GV.missile5.Location = new Point(GV.ranGen.Next(1, this.Width - 1), 1);
                GV.score++;
                GV.igScore.Text = GV.score.ToString();
            }
        }
    }

    //highscore class NOT ACTIVE
    [Serializable]
    public class Highscore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }

    //Powerup class OK
    public class Powerups
    {
        GameVars GV = new GameVars();

        public PictureBox powerup = new PictureBox();
        private Random ranGen = new Random();
        public Timer movePowerupTimer = new Timer();
        private Timer powerupTimer = new Timer();
        private int counter = 0;

        Stream str = GameMethods.Resource11.Powerup;
        //private SoundPlayer sp;

        public int height { get; set; }

        //constructor, set image OK
        public Powerups(Image img)
        {
            powerup.Image = img;
        }

        //set properties of powerup and return OK
        public PictureBox addPowerup(int x)
        {
            powerup.Size = new Size(50, 50);
            powerup.SizeMode = PictureBoxSizeMode.Zoom;
            powerup.Location = new Point(ranGen.Next(1, x -1), 1);
            return powerup;
        }

        //move OK
        public void movePowerup()
        {
            movePowerupTimer.Tick += new EventHandler(movePowerupTimer_Tick);
            movePowerupTimer.Interval = 5;
            movePowerupTimer.Start();
        }

        //MovePowerup timer OK
        private void movePowerupTimer_Tick(Object sender, EventArgs e)
        {
            powerup.Location = new Point(powerup.Location.X, powerup.Location.Y + 1);
        }

        //if catched call this OK
        public void usePowerup()
        {
            //play sound
            //sp = new SoundPlayer(str);
            //sp.Play();

            //choose random powerup
            switch (ranGen.Next(1, 5))
            {
                case 1:
                    GV.shield += 1;
                    break;
                case 2:
                    GV.jetSpeed += 5;
                    counter = 20;
                    StartPowerupTimer();
                    break;
                case 3:
                    GV.jet.Visible = false;
                    counter = 5;
                    StartPowerupTimer();
                    break;
                default:
                    GV.score += 50;
                    break;
            }
        }

        //create powerup timer OK
        private void StartPowerupTimer()
        {
            powerupTimer.Interval = 1000;
            powerupTimer.Tick += new EventHandler(powerupTimer_Tick);
            powerupTimer.Start();
        }

        //powerup timer event OK
        private void powerupTimer_Tick(Object sender, EventArgs e)
        {
            if (counter == 0)
            {
                GV.jet.Visible = true;
                powerupTimer.Stop();
            }

            if (counter == 0)
            {
                GV.jetSpeed = 3;
                powerupTimer.Stop();
            }

            counter--;
        }
    }

    //GameVars class OK
    public class GameVars
    {
        //constructor
        public GameVars()
        {
            
        }

        //vars
        public bool gameover = false;
        public bool powerupSpawned = false;
        public bool sideMissileSpawned = false;
        public bool missile2spawned = false;
        public bool missile3spawned = false;
        public bool missile4spawned = false;
        public bool missile5spawned = false;
        public int counter = 4;
        public int score = 0;
        public int shield = 1;
        public int speed = 3;
        public int jetSpeed = 10;
        public int counter2 = 0;
        public string playername = "player1";

        //Objects
        public Random ranGen = new Random();
        public Label cdLabel = new Label();
        public Label igScore = new Label();
        public Label sbLabel = new Label();
        public Timer cdTimer = new Timer();

        public PictureBox sideMissile;
        public PictureBox missile1;
        public PictureBox missile2;
        public PictureBox missile3;
        public PictureBox missile4;
        public PictureBox missile5;
        public PictureBox jet;

        //countdown timer
        public void setPropertiescdTimer()
        {
            cdTimer.Interval = 1000;
        }
        
        //missile
        private PictureBox Missile(int width)
        {
            PictureBox missile = new PictureBox();
            missile.Size = new Size(50, 100);
            missile.Image = GameMethods.Resource7.missileFixedHitbox;
            missile.SizeMode = PictureBoxSizeMode.Zoom;
            missile.Location = new Point(ranGen.Next(1, width), 1);
            missile.BringToFront();

            return missile;
        }

        //create missile
        public void CreateMissile(ref PictureBox missile, int width)
        {
            missile = Missile(width);
        }

        //side missile
        private PictureBox PropertiesSideMissile(int height)
        {
            PictureBox sMissile = new PictureBox();
            sMissile.Size = new Size(100, 50);
            sMissile.Image = GameMethods.Resource12.sideMissile;
            sMissile.SizeMode = PictureBoxSizeMode.Zoom;
            sMissile.Location = new Point(1, ranGen.Next(1, height));

            return sMissile;
        }

        //create side missile
        public void CreateSideMissile(ref PictureBox sMissile, int height)
        {
            sMissile = PropertiesSideMissile(height);
        }

        //jet
        private PictureBox Jet(int x, int y)
        {
            PictureBox jet = new PictureBox();
            jet.Size = new Size(140, 170);
            jet.Image = GameMethods.Resource6.FighterJetFixedHitbox;
            jet.SizeMode = PictureBoxSizeMode.Zoom;
            jet.Location = new Point(x, y);

            return jet;
        }

        //create jet
        public void CreateJet(int x, int y)
        {
            jet = Jet(x, y);
        }
    }

    //side moving objects class TEST
    public class MoreMissiles
    {
        GameVars GV = new GameVars();

        public Timer moveMissile = new Timer();

        public int width { get; set; }
        public int height { get; set; }

        //constructor OK
        public MoreMissiles()
        {

        }

        //move OK
        public void moveSideMissile()
        {
            moveMissile.Tick += new EventHandler(moveMissile_Tick);
            moveMissile.Interval = 5;
            moveMissile.Start();
        }

        //MovePowerup timer OK
        private void moveMissile_Tick(Object sender, EventArgs e)
        {
            GV.sideMissile.Location = new Point(GV.sideMissile.Location.X + GV.speed, GV.sideMissile.Location.Y);

            if (GV.sideMissile.Location.X >= width)
            {
                GV.sideMissile.Location = new Point(1, GV.ranGen.Next(1, height -1));
                GV.score++;
                GV.igScore.Text = GV.score.ToString();
            }
        }
    }
}
