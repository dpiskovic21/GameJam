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
            SuspendLayout();
            // 
            // handCard1
            // 
            handCard1.Location = new Point(321, 804);
            handCard1.Name = "handCard1";
            handCard1.Size = new Size(157, 199);
            handCard1.TabIndex = 0;
            handCard1.UseVisualStyleBackColor = true;
            // 
            // handCard2
            // 
            handCard2.Location = new Point(497, 804);
            handCard2.Name = "handCard2";
            handCard2.Size = new Size(157, 199);
            handCard2.TabIndex = 1;
            handCard2.UseVisualStyleBackColor = true;
            // 
            // handCard3
            // 
            handCard3.Location = new Point(674, 804);
            handCard3.Name = "handCard3";
            handCard3.Size = new Size(157, 199);
            handCard3.TabIndex = 2;
            handCard3.UseVisualStyleBackColor = true;
            // 
            // handCard4
            // 
            handCard4.Location = new Point(854, 804);
            handCard4.Name = "handCard4";
            handCard4.Size = new Size(157, 199);
            handCard4.TabIndex = 3;
            handCard4.UseVisualStyleBackColor = true;
            // 
            // handCard5
            // 
            handCard5.Location = new Point(1027, 804);
            handCard5.Name = "handCard5";
            handCard5.Size = new Size(157, 199);
            handCard5.TabIndex = 4;
            handCard5.UseVisualStyleBackColor = true;
            // 
            // btnDeck
            // 
            btnDeck.Font = new Font("Segoe UI", 20F);
            btnDeck.Location = new Point(1701, 755);
            btnDeck.Name = "btnDeck";
            btnDeck.Size = new Size(157, 199);
            btnDeck.TabIndex = 5;
            btnDeck.UseVisualStyleBackColor = true;
            // 
            // labelCurrentHandBalance
            // 
            labelCurrentHandBalance.AutoSize = true;
            labelCurrentHandBalance.Font = new Font("Segoe UI", 20F);
            labelCurrentHandBalance.Location = new Point(43, 847);
            labelCurrentHandBalance.Name = "labelCurrentHandBalance";
            labelCurrentHandBalance.Size = new Size(0, 37);
            labelCurrentHandBalance.TabIndex = 6;
            // 
            // labelEnergy
            // 
            labelEnergy.AutoSize = true;
            labelEnergy.Font = new Font("Segoe UI", 20F);
            labelEnergy.Location = new Point(1701, 708);
            labelEnergy.Name = "labelEnergy";
            labelEnergy.Size = new Size(0, 37);
            labelEnergy.TabIndex = 7;
            // 
            // altarCard1
            // 
            altarCard1.Location = new Point(335, 241);
            altarCard1.Name = "altarCard1";
            altarCard1.Size = new Size(157, 199);
            altarCard1.TabIndex = 8;
            altarCard1.UseVisualStyleBackColor = true;
            // 
            // altarCard2
            // 
            altarCard2.Location = new Point(518, 241);
            altarCard2.Name = "altarCard2";
            altarCard2.Size = new Size(157, 199);
            altarCard2.TabIndex = 9;
            altarCard2.UseVisualStyleBackColor = true;
            // 
            // altarCard3
            // 
            altarCard3.Location = new Point(695, 241);
            altarCard3.Name = "altarCard3";
            altarCard3.Size = new Size(157, 199);
            altarCard3.TabIndex = 10;
            altarCard3.UseVisualStyleBackColor = true;
            // 
            // MainPlayAreaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
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
    }
}