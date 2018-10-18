namespace TicTacToiUI
{
    public partial class TicTacToeGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicTacToeGameForm));
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.labelPlayer1N = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.labelPlayer2N = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Location = new System.Drawing.Point(59, 284);
            this.labelPlayer1Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(0, 17);
            this.labelPlayer1Name.TabIndex = 0;
            // 
            // labelPlayer1N
            // 
            this.labelPlayer1N.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer1N.AutoSize = true;
            this.labelPlayer1N.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1N.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelPlayer1N.Location = new System.Drawing.Point(13, 361);
            this.labelPlayer1N.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer1N.Name = "labelPlayer1N";
            this.labelPlayer1N.Size = new System.Drawing.Size(73, 17);
            this.labelPlayer1N.TabIndex = 1;
            this.labelPlayer1N.Text = "Player1 :";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Location = new System.Drawing.Point(91, 361);
            this.labelPlayer1Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(16, 17);
            this.labelPlayer1Score.TabIndex = 2;
            this.labelPlayer1Score.Text = "0";
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Location = new System.Drawing.Point(220, 361);
            this.labelPlayer2Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(16, 17);
            this.labelPlayer2Score.TabIndex = 4;
            this.labelPlayer2Score.Text = "0";
            // 
            // labelPlayer2N
            // 
            this.labelPlayer2N.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2N.AutoSize = true;
            this.labelPlayer2N.Location = new System.Drawing.Point(144, 361);
            this.labelPlayer2N.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer2N.Name = "labelPlayer2N";
            this.labelPlayer2N.Size = new System.Drawing.Size(64, 17);
            this.labelPlayer2N.TabIndex = 3;
            this.labelPlayer2N.Text = "Player2 :";
            // 
            // TicTacToeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 388);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer2N);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.labelPlayer1N);
            this.Controls.Add(this.labelPlayer1Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TicTacToeGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicTacToeGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer1N;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.Label labelPlayer2N;
    }
}