using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;

namespace Chess_Engine_Project
{
    public partial class BoardUI : Form
    {

		public Bitmap board = new Bitmap(800, 800);

		public BoardUI()
        {
            InitializeComponent();
        }

        private void BoardUI_Load(object sender, EventArgs e)
        {
			this.CenterToScreen();
			DrawBoardToScreen();
        }

		public void DrawBoardToScreen()
		{

			
			Graphics g = Graphics.FromImage(board);

			for (int file = 0; file < 8; file++)
			{
				for (int rank = 0; rank < 8; rank++)
				{
					bool isLightSquare = (file + rank) % 2 == 1;
					if (isLightSquare)
					{
						//filling in light squares
						g.FillRectangle(Brushes.DarkKhaki, file * 100, rank * 100, 100, 100);
					}
					else
					{
						//filling in dark squares 
						g.FillRectangle(Brushes.Sienna, file * 100, rank * 100, 100, 100);
					}
				}
			}
			boardImageBox.Image = board;
			DrawPiecesToBoard();
		}

		public void DrawPiecesToBoard() 
		{
			Graphics g = Graphics.FromImage(board);
			Font font = new Font("UTF-8", 52);

			//black pieces
			for (int file = 0; file < 8; file++)
			{
				g.DrawString("♟", font, Brushes.Black, file*100, 100);
			}
			g.DrawString("♜", font, Brushes.Black, 0, 0);
			g.DrawString("♞", font, Brushes.Black, 100, 0);
			g.DrawString("♝", font, Brushes.Black, 200, 0);
			g.DrawString("♛", font, Brushes.Black, 300, 0);
			g.DrawString("♚", font, Brushes.Black, 400, 0);
			g.DrawString("♝", font, Brushes.Black, 500, 0);
			g.DrawString("♞", font, Brushes.Black, 600, 0);
			g.DrawString("♜", font, Brushes.Black, 700,  0);

			//white pieces
			for (int file = 0; file < 8; file++)
			{
				g.DrawString("♙", font, Brushes.White, file*100, 600);
			}
			g.DrawString("♖", font, Brushes.White, 0, 700);
			g.DrawString("♘", font, Brushes.White, 100, 700);
			g.DrawString("♗", font, Brushes.White, 200, 700);
			g.DrawString("♕", font, Brushes.White, 300, 700);
			g.DrawString("♔", font, Brushes.White, 400, 700);
			g.DrawString("♗", font, Brushes.White, 500, 700);
			g.DrawString("♘", font, Brushes.White, 600, 700);
			g.DrawString("♖", font, Brushes.White, 700, 700);



		}
	}
}
