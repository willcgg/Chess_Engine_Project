
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
            this.boardImageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.boardImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // boardImageBox
            // 
            this.boardImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boardImageBox.ImageLocation = "";
            this.boardImageBox.Location = new System.Drawing.Point(40, 40);
            this.boardImageBox.Name = "boardImageBox";
            this.boardImageBox.Size = new System.Drawing.Size(800, 800);
            this.boardImageBox.TabIndex = 0;
            this.boardImageBox.TabStop = false;
            // 
            // BoardUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.boardImageBox);
            this.Name = "BoardUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BoardUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boardImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boardImageBox;
    }
}

