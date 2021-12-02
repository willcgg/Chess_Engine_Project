using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Engine_Project
{
    public partial class BoardUI : Form
    {
        public BoardUI()
        {
            InitializeComponent();
        }

        private void BoardUI_Load(object sender, EventArgs e)
        {
			this.CenterToScreen();
			drawBoard();
        }

		public void drawBoard()
		{
			Bitmap board = new Bitmap(800, 800);
			Graphics g = Graphics.FromImage(board);

			for (int file = 0; file < 8; file++)
			{
				for (int rank = 0; rank < 8; rank++)
				{
					bool isLightSquare = (file + rank) % 2 == 1;
					if (isLightSquare)
					{
						//filling in light squares
						g.FillRectangle(Brushes.Wheat, file * 100, rank * 100, 100, 100);
					}
					else
					{
						//filling in dark squares 
						g.FillRectangle(Brushes.Sienna, file * 100, rank * 100, 100, 100);
					}
				}
			}
			boardImageBox.Image = board;
		}

		public void loadPieces() 
		{

		}
	}
}
