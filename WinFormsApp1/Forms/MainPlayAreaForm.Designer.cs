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
            btnCancelSwap = new Button();
            gpReplacePrompt = new GroupBox();
            label1 = new Label();
            labelScore = new Label();
            pbPeekCard = new PictureBox();
            labelCurrentModifier = new Label();
            gpReplacePrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPeekCard).BeginInit();
            SuspendLayout();
            // 
            // handCard1
            // 
            handCard1.Location = new Point(217, 703);
            handCard1.Name = "handCard1";
            handCard1.Size = new Size(200, 300);
            handCard1.TabIndex = 0;
            handCard1.UseVisualStyleBackColor = true;
            // 
            // handCard2
            // 
            handCard2.Location = new Point(447, 703);
            handCard2.Name = "handCard2";
            handCard2.Size = new Size(200, 300);
            handCard2.TabIndex = 1;
            handCard2.UseVisualStyleBackColor = true;
            // 
            // handCard3
            // 
            handCard3.Location = new Point(676, 703);
            handCard3.Name = "handCard3";
            handCard3.Size = new Size(200, 300);
            handCard3.TabIndex = 2;
            handCard3.UseVisualStyleBackColor = true;
            // 
            // handCard4
            // 
            handCard4.Location = new Point(903, 703);
            handCard4.Name = "handCard4";
            handCard4.Size = new Size(200, 300);
            handCard4.TabIndex = 3;
            handCard4.UseVisualStyleBackColor = true;
            // 
            // handCard5
            // 
            handCard5.Location = new Point(1128, 703);
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
            // btnCancelSwap
            // 
            btnCancelSwap.Location = new Point(3, 52);
            btnCancelSwap.Name = "btnCancelSwap";
            btnCancelSwap.Size = new Size(223, 42);
            btnCancelSwap.TabIndex = 14;
            btnCancelSwap.Text = "Cancle swap";
            btnCancelSwap.UseVisualStyleBackColor = true;
            btnCancelSwap.Click += btnCancelSwap_Click;
            // 
            // gpReplacePrompt
            // 
            gpReplacePrompt.Controls.Add(label1);
            gpReplacePrompt.Controls.Add(btnCancelSwap);
            gpReplacePrompt.Location = new Point(661, 508);
            gpReplacePrompt.Name = "gpReplacePrompt";
            gpReplacePrompt.Size = new Size(232, 100);
            gpReplacePrompt.TabIndex = 15;
            gpReplacePrompt.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(226, 28);
            label1.TabIndex = 15;
            label1.Text = "Select an altar card swap";
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
            // MainPlayAreaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(labelCurrentModifier);
            Controls.Add(pbPeekCard);
            Controls.Add(labelScore);
            Controls.Add(gpReplacePrompt);
            Controls.Add(labelCurrentBalance);
            Controls.Add(btnEndRound);
            Controls.Add(labelDay);
            Controls.Add(altarCard3);
            Controls.Add(altarCard2);
            Controls.Add(altarCard1);
            Controls.Add(labelEnergy);
            Controls.Add(labelCurrentHandBalance);
            Controls.Add(btnDeck);
            Controls.Add(handCard5);
            Controls.Add(handCard4);
            Controls.Add(handCard3);
            Controls.Add(handCard2);
            Controls.Add(handCard1);
            Name = "MainPlayAreaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MainPlayAreaForm";
            Load += MainPlayAreaForm_Load;
            gpReplacePrompt.ResumeLayout(false);
            gpReplacePrompt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPeekCard).EndInit();
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
        private GroupBox gpReplacePrompt;
        private Label label1;
        private Label labelScore;
        private PictureBox pbPeekCard;
        private Label labelCurrentModifier;
    }
}