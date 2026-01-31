namespace WinFormsApp1.Forms
{
    partial class StartMenuForm
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
            btnStart = new Button();
            btnExit = new Button();
            btnLeaderboard = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(851, 633);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(233, 90);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(851, 758);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(233, 90);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit game";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLeaderboard
            // 
            btnLeaderboard.Location = new Point(851, 879);
            btnLeaderboard.Name = "btnLeaderboard";
            btnLeaderboard.Size = new Size(233, 90);
            btnLeaderboard.TabIndex = 2;
            btnLeaderboard.Text = "Leaderboard";
            btnLeaderboard.UseVisualStyleBackColor = true;
            btnLeaderboard.Click += btnLeaderboard_Click;
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btnLeaderboard);
            Controls.Add(btnExit);
            Controls.Add(btnStart);
            Name = "StartMenuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "StartMenuForm";
            Load += StartMenuForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnExit;
        private Button btnLeaderboard;
    }
}