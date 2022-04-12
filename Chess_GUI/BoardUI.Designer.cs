
namespace Chess_Engine_Project
{
    partial class BoardUI
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
            this.BoardPictureBox = new System.Windows.Forms.PictureBox();
            this.FENLabel = new System.Windows.Forms.Label();
            this.FENTextBox = new System.Windows.Forms.TextBox();
            this.FENGenerateButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.BoardControlBox = new System.Windows.Forms.GroupBox();
            this.FEN_FORM_LABEL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPictureBox)).BeginInit();
            this.BoardControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoardPictureBox
            // 
            this.BoardPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.BoardPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoardPictureBox.ImageLocation = "";
            this.BoardPictureBox.Location = new System.Drawing.Point(13, 14);
            this.BoardPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.BoardPictureBox.Name = "BoardPictureBox";
            this.BoardPictureBox.Size = new System.Drawing.Size(825, 825);
            this.BoardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BoardPictureBox.TabIndex = 0;
            this.BoardPictureBox.TabStop = false;
            this.BoardPictureBox.Click += new System.EventHandler(this.BoardPictureBox_Click);
            // 
            // FENLabel
            // 
            this.FENLabel.AutoSize = true;
            this.FENLabel.Font = new System.Drawing.Font("Arial", 16F);
            this.FENLabel.Location = new System.Drawing.Point(6, 106);
            this.FENLabel.Name = "FENLabel";
            this.FENLabel.Size = new System.Drawing.Size(85, 32);
            this.FENLabel.TabIndex = 1;
            this.FENLabel.Text = "FEN: ";
            // 
            // FENTextBox
            // 
            this.FENTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.FENTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.FENTextBox.Location = new System.Drawing.Point(96, 91);
            this.FENTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FENTextBox.Name = "FENTextBox";
            this.FENTextBox.Size = new System.Drawing.Size(521, 27);
            this.FENTextBox.TabIndex = 2;
            this.FENTextBox.Text = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            // 
            // FENGenerateButton
            // 
            this.FENGenerateButton.BackColor = System.Drawing.SystemColors.Info;
            this.FENGenerateButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FENGenerateButton.FlatAppearance.BorderSize = 2;
            this.FENGenerateButton.Font = new System.Drawing.Font("Arial", 12F);
            this.FENGenerateButton.Location = new System.Drawing.Point(96, 128);
            this.FENGenerateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FENGenerateButton.Name = "FENGenerateButton";
            this.FENGenerateButton.Size = new System.Drawing.Size(521, 43);
            this.FENGenerateButton.TabIndex = 3;
            this.FENGenerateButton.Text = "Generate Board";
            this.FENGenerateButton.UseVisualStyleBackColor = false;
            this.FENGenerateButton.Click += new System.EventHandler(this.FENGenerateButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.Info;
            this.BackButton.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(128, 204);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(200, 63);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.SystemColors.Info;
            this.NextButton.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(372, 204);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(195, 63);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            // 
            // BoardControlBox
            // 
            this.BoardControlBox.BackColor = System.Drawing.SystemColors.Control;
            this.BoardControlBox.Controls.Add(this.FEN_FORM_LABEL);
            this.BoardControlBox.Controls.Add(this.FENLabel);
            this.BoardControlBox.Controls.Add(this.NextButton);
            this.BoardControlBox.Controls.Add(this.FENTextBox);
            this.BoardControlBox.Controls.Add(this.FENGenerateButton);
            this.BoardControlBox.Controls.Add(this.BackButton);
            this.BoardControlBox.Location = new System.Drawing.Point(1126, 229);
            this.BoardControlBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoardControlBox.Name = "BoardControlBox";
            this.BoardControlBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoardControlBox.Size = new System.Drawing.Size(757, 316);
            this.BoardControlBox.TabIndex = 6;
            this.BoardControlBox.TabStop = false;
            this.BoardControlBox.Text = "Game State";
            // 
            // FEN_FORM_LABEL
            // 
            this.FEN_FORM_LABEL.AutoSize = true;
            this.FEN_FORM_LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.FEN_FORM_LABEL.Location = new System.Drawing.Point(253, 30);
            this.FEN_FORM_LABEL.Name = "FEN_FORM_LABEL";
            this.FEN_FORM_LABEL.Size = new System.Drawing.Size(137, 31);
            this.FEN_FORM_LABEL.TabIndex = 6;
            this.FEN_FORM_LABEL.Text = "FEN Input";
            // 
            // BoardUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.BoardControlBox);
            this.Controls.Add(this.BoardPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BoardUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Chess Engine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BoardUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BoardPictureBox)).EndInit();
            this.BoardControlBox.ResumeLayout(false);
            this.BoardControlBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BoardPictureBox;
        private System.Windows.Forms.Label FENLabel;
        private System.Windows.Forms.TextBox FENTextBox;
        private System.Windows.Forms.Button FENGenerateButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.GroupBox BoardControlBox;
        private System.Windows.Forms.Label FEN_FORM_LABEL;
    }
}

