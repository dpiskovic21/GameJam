namespace WinFormsApp1.Forms
{
    partial class Leaderboard
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
            dgvLeaderboard = new DataGridView();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLeaderboard).BeginInit();
            SuspendLayout();
            // 
            // dgvLeaderboard
            // 
            dgvLeaderboard.AllowUserToAddRows = false;
            dgvLeaderboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaderboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaderboard.Location = new Point(500, 220);
            dgvLeaderboard.Name = "dgvLeaderboard";
            dgvLeaderboard.ReadOnly = true;
            dgvLeaderboard.RowHeadersVisible = false;
            dgvLeaderboard.Size = new Size(920, 600);
            dgvLeaderboard.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(846, 870);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(233, 90);
            btnExit.TabIndex = 1;
            btnExit.Text = "Back";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Leaderboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btnExit);
            Controls.Add(dgvLeaderboard);
            Name = "Leaderboard";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Leaderboard";
            Load += Leaderboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLeaderboard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLeaderboard;
        private Button btnExit;
    }
}