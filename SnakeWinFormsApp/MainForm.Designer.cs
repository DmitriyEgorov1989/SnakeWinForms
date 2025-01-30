namespace SnakeWinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            scoreCountLabel = new Label();
            label = new Label();
            SuspendLayout();
            // 
            // scoreCountLabel
            // 
            scoreCountLabel.AutoSize = true;
            scoreCountLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            scoreCountLabel.ForeColor = Color.Chartreuse;
            scoreCountLabel.Location = new Point(85, 0);
            scoreCountLabel.Name = "scoreCountLabel";
            scoreCountLabel.Size = new Size(24, 28);
            scoreCountLabel.TabIndex = 0;
            scoreCountLabel.Text = "0";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label.ForeColor = Color.Chartreuse;
            label.Location = new Point(-1, 0);
            label.Name = "label";
            label.Size = new Size(80, 28);
            label.TabIndex = 1;
            label.Text = "Очки  :";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(782, 753);
            Controls.Add(label);
            Controls.Add(scoreCountLabel);
            ForeColor = SystemColors.WindowFrame;
            Name = "MainForm";
            Text = "TheSnake";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreCountLabel;
        private Label label;
    }
}
