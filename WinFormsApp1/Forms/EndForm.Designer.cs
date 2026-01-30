namespace WinFormsApp1.Forms
{
    partial class EndForm
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
            labelOver = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // labelOver
            // 
            labelOver.AutoSize = true;
            labelOver.Font = new Font("Segoe UI", 50F);
            labelOver.Location = new Point(644, 247);
            labelOver.Name = "labelOver";
            labelOver.Size = new Size(275, 89);
            labelOver.TabIndex = 0;
            labelOver.Text = "The End";
            // 
            // button1
            // 
            button1.Location = new Point(657, 426);
            button1.Name = "button1";
            button1.Size = new Size(262, 23);
            button1.TabIndex = 1;
            button1.Text = "Back to main menu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EndForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(labelOver);
            Name = "EndForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EndForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelOver;
        private Button button1;
    }
}