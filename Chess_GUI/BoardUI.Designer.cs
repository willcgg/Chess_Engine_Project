
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 855);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 855);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(351, 855);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "D";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(246, 855);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(762, 855);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "H";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(649, 855);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "G";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(561, 855);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 29);
            this.label7.TabIndex = 12;
            this.label7.Text = "F";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(452, 855);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 29);
            this.label8.TabIndex = 11;
            this.label8.Text = "E";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(862, 771);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 29);
            this.label9.TabIndex = 15;
            this.label9.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(862, 662);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 29);
            this.label10.TabIndex = 16;
            this.label10.Text = "2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(862, 557);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 29);
            this.label11.TabIndex = 17;
            this.label11.Text = "3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(862, 467);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 29);
            this.label12.TabIndex = 18;
            this.label12.Text = "4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(862, 357);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 29);
            this.label13.TabIndex = 19;
            this.label13.Text = "5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(862, 259);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 29);
            this.label14.TabIndex = 20;
            this.label14.Text = "6";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(862, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 29);
            this.label15.TabIndex = 21;
            this.label15.Text = "8";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(862, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 29);
            this.label16.TabIndex = 22;
            this.label16.Text = "7";
            // 
            // BoardUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}

