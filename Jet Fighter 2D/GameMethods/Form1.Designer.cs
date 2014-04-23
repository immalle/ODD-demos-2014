namespace JetFighter2D
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.scoreButton = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.PictureBox();
            this.startPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 4;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // exitButton
            // 
            this.exitButton.Image = global::JetFighter2D.Properties.Resources.quitbuttonbutton;
            this.exitButton.Location = new System.Drawing.Point(1337, 946);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(134, 66);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitButton.TabIndex = 7;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.scoreButton.Image = global::JetFighter2D.Properties.Resources.HighscoreButtonbutton2;
            this.scoreButton.Location = new System.Drawing.Point(1200, 852);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(405, 66);
            this.scoreButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.scoreButton.TabIndex = 6;
            this.scoreButton.TabStop = false;
            this.scoreButton.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.Image = global::JetFighter2D.Resource1.playbuttonbutton;
            this.startButton.Location = new System.Drawing.Point(141, 823);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(370, 158);
            this.startButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.startButton.TabIndex = 5;
            this.startButton.TabStop = false;
            this.startButton.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // startPictureBox
            // 
            this.startPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.startPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPictureBox.Image = global::JetFighter2D.Resource1.StartscreenFiXed;
            this.startPictureBox.Location = new System.Drawing.Point(0, 0);
            this.startPictureBox.Name = "startPictureBox";
            this.startPictureBox.Size = new System.Drawing.Size(1680, 1050);
            this.startPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.startPictureBox.TabIndex = 1;
            this.startPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 1050);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.startPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Jet Fighter 2D";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox startPictureBox;
        private System.Windows.Forms.PictureBox startButton;
        private System.Windows.Forms.PictureBox scoreButton;
        private System.Windows.Forms.PictureBox exitButton;
    }
}

