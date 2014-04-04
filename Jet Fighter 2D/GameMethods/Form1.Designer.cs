namespace GameMethods
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
            this.startPictureBox = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.scoreButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.startPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 4;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // startPictureBox
            // 
            this.startPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.startPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPictureBox.Image = global::GameMethods.Resource1.Startscreen;
            this.startPictureBox.Location = new System.Drawing.Point(0, 0);
            this.startPictureBox.Name = "startPictureBox";
            this.startPictureBox.Size = new System.Drawing.Size(738, 344);
            this.startPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.startPictureBox.TabIndex = 1;
            this.startPictureBox.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.Location = new System.Drawing.Point(13, 309);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Play!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.scoreButton.Location = new System.Drawing.Point(269, 309);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(200, 23);
            this.scoreButton.TabIndex = 3;
            this.scoreButton.Text = "Scoreboard";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(526, 309);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Quit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 4;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 4;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 4;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 4;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 344);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.startPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Jet Fighter 2D";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox startPictureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
    }
}

