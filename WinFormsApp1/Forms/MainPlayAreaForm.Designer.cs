namespace WinFormsApp1.Forms
{
    partial class MainPlayAreaForm
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
            handCard1 = new Button();
            handCard2 = new Button();
            handCard3 = new Button();
            handCard4 = new Button();
            handCard5 = new Button();
            btnDeck = new Button();
            labelCurrentHandBalance = new Label();
            labelEnergy = new Label();
            altarCard1 = new Button();
            altarCard2 = new Button();
            altarCard3 = new Button();
            labelDay = new Label();
            btnEndRound = new Button();
            labelCurrentBalance = new Label();
            labelScore = new Label();
            pbPeekCard = new PictureBox();
            labelCurrentModifier = new Label();
            gbHand = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pbPeekCard).BeginInit();
            gbHand.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // handCard1
            // 
            handCard1.Location = new Point(3, 3);
            handCard1.Name = "handCard1";
            handCard1.Size = new Size(200, 300);
            handCard1.TabIndex = 0;
            handCard1.UseVisualStyleBackColor = true;
            // 
            // handCard2
            // 
            handCard2.Location = new Point(209, 3);
            handCard2.Name = "handCard2";
            handCard2.Size = new Size(200, 300);
            handCard2.TabIndex = 1;
            handCard2.UseVisualStyleBackColor = true;
            // 
            // handCard3
            // 
            handCard3.Location = new Point(415, 3);
            handCard3.Name = "handCard3";
            handCard3.Size = new Size(200, 300);
            handCard3.TabIndex = 2;
            handCard3.UseVisualStyleBackColor = true;
            // 
            // handCard4
            // 
            handCard4.Location = new Point(621, 3);
            handCard4.Name = "handCard4";
            handCard4.Size = new Size(200, 300);
            handCard4.TabIndex = 3;
            handCard4.UseVisualStyleBackColor = true;
            // 
            // handCard5
            // 
            handCard5.Location = new Point(827, 3);
            handCard5.Name = "handCard5";
            handCard5.Size = new Size(200, 300);
            handCard5.TabIndex = 4;
            handCard5.UseVisualStyleBackColor = true;
            // 
            // btnDeck
            // 
            btnDeck.Location = new Point(1640, 650);
            btnDeck.Name = "btnDeck";
            btnDeck.Size = new Size(200, 300);
            btnDeck.TabIndex = 5;
            btnDeck.UseVisualStyleBackColor = true;
            btnDeck.Click += btnDeck_Click;
            btnDeck.MouseEnter += btnDeck_MouseEnter;
            btnDeck.MouseLeave += btnDeck_MouseLeave;
            // 
            // labelCurrentHandBalance
            // 
            labelCurrentHandBalance.AutoSize = true;
            labelCurrentHandBalance.Location = new Point(43, 847);
            labelCurrentHandBalance.Name = "labelCurrentHandBalance";
            labelCurrentHandBalance.Size = new Size(0, 15);
            labelCurrentHandBalance.TabIndex = 6;
            // 
            // labelEnergy
            // 
            labelEnergy.AutoSize = true;
            labelEnergy.Location = new Point(1668, 632);
            labelEnergy.Name = "labelEnergy";
            labelEnergy.Size = new Size(0, 15);
            labelEnergy.TabIndex = 7;
            // 
            // altarCard1
            // 
            altarCard1.Location = new Point(424, 138);
            altarCard1.Name = "altarCard1";
            altarCard1.Size = new Size(200, 300);
            altarCard1.TabIndex = 8;
            altarCard1.UseVisualStyleBackColor = true;
            // 
            // altarCard2
            // 
            altarCard2.Location = new Point(664, 138);
            altarCard2.Name = "altarCard2";
            altarCard2.Size = new Size(200, 300);
            altarCard2.TabIndex = 9;
            altarCard2.UseVisualStyleBackColor = true;
            // 
            // altarCard3
            // 
            altarCard3.Location = new Point(903, 138);
            altarCard3.Name = "altarCard3";
            altarCard3.Size = new Size(200, 300);
            altarCard3.TabIndex = 10;
            altarCard3.UseVisualStyleBackColor = true;
            // 
            // labelDay
            // 
            labelDay.AutoSize = true;
            labelDay.BackColor = Color.Transparent;
            labelDay.Location = new Point(637, 35);
            labelDay.Name = "labelDay";
            labelDay.Size = new Size(0, 15);
            labelDay.TabIndex = 11;
            // 
            // btnEndRound
            // 
            btnEndRound.Location = new Point(1668, 960);
            btnEndRound.Name = "btnEndRound";
            btnEndRound.Size = new Size(157, 43);
            btnEndRound.TabIndex = 12;
            btnEndRound.Text = "End  Day";
            btnEndRound.UseVisualStyleBackColor = true;
            btnEndRound.Click += btnEndRound_Click;
            // 
            // labelCurrentBalance
            // 
            labelCurrentBalance.AutoSize = true;
            labelCurrentBalance.Location = new Point(1417, 593);
            labelCurrentBalance.Name = "labelCurrentBalance";
            labelCurrentBalance.Size = new Size(0, 15);
            labelCurrentBalance.TabIndex = 13;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Location = new Point(1541, 200);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(0, 15);
            labelScore.TabIndex = 16;
            // 
            // pbPeekCard
            // 
            pbPeekCard.Location = new Point(1640, 319);
            pbPeekCard.Name = "pbPeekCard";
            pbPeekCard.Size = new Size(200, 300);
            pbPeekCard.TabIndex = 17;
            pbPeekCard.TabStop = false;
            // 
            // labelCurrentModifier
            // 
            labelCurrentModifier.AutoSize = true;
            labelCurrentModifier.Location = new Point(22, 914);
            labelCurrentModifier.Name = "labelCurrentModifier";
            labelCurrentModifier.Size = new Size(0, 15);
            labelCurrentModifier.TabIndex = 18;
            // 
            // gbHand
            // 
            gbHand.BackColor = Color.Transparent;
            gbHand.Controls.Add(flowLayoutPanel1);
            gbHand.FlatStyle = FlatStyle.Flat;
            gbHand.Location = new Point(215, 577);
            gbHand.Name = "gbHand";
            gbHand.Size = new Size(1037, 341);
            gbHand.TabIndex = 19;
            gbHand.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(handCard1);
            flowLayoutPanel1.Controls.Add(handCard2);
            flowLayoutPanel1.Controls.Add(handCard3);
            flowLayoutPanel1.Controls.Add(handCard4);
            flowLayoutPanel1.Controls.Add(handCard5);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1031, 319);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // MainPlayAreaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(gbHand);
            Controls.Add(labelCurrentModifier);
            Controls.Add(pbPeekCard);
            Controls.Add(labelScore);
            Controls.Add(labelCurrentBalance);
            Controls.Add(btnEndRound);
            Controls.Add(labelDay);
            Controls.Add(altarCard3);
            Controls.Add(altarCard2);
            Controls.Add(altarCard1);
            Controls.Add(labelEnergy);
            Controls.Add(labelCurrentHandBalance);
            Controls.Add(btnDeck);
            Name = "MainPlayAreaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MainPlayAreaForm";
            Load += MainPlayAreaForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbPeekCard).EndInit();
            gbHand.ResumeLayout(false);
            gbHand.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button handCard1;
        private Button handCard2;
        private Button handCard3;
        private Button handCard4;
        private Button handCard5;
        private Button btnDeck;
        private Label labelCurrentHandBalance;
        private Label labelEnergy;
        private Button altarCard1;
        private Button altarCard2;
        private Button altarCard3;
        private Label labelDay;
        private Button btnEndRound;
        private Label labelCurrentBalance;
        private Button btnCancelSwap;
        private Label label1;
        private Label labelScore;
        private PictureBox pbPeekCard;
        private Label labelCurrentModifier;
        private GroupBox gbHand;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}