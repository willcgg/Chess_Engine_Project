using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_Engine_Project
{
    /// <summary>
    /// Class to display the board and its pieces to the user and also handle all form controls.
    /// </summary>
    public partial class BoardUI : Form
    {

		public Bitmap board = new Bitmap(800, 800);

		public BoardUI()
        {
            InitializeComponent();
        }

        private void BoardUI_Load(object sender, EventArgs e)
        {
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
						//filling in dark squares
						g.FillRectangle(Brushes.SlateGray, file * 100, rank * 100, 100, 100);
					}
					else
					{
						//filling in light squares 
						g.FillRectangle(Brushes.LightSteelBlue, file * 100, rank * 100, 100, 100);
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

        private void FENGenerateButton_Click(object sender, EventArgs e)
        {
			// Error checking
			if (FENTextBox.Text == "")
			{
				MessageBox.Show("Please enter a valid FEN string.\n\tFormat: e.g. rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq 1 0");
			}
			else
            {
				// Try run it through the engine FEN_Handler, if it creates error then do not accept the FEN
				try
				{
					// FEN_Handler handler = new FEN_Handler(FENTextBox.Text, Board.board);
				}
				catch (Exception ex) 
				{
					MessageBox.Show("Error creating board from FEN, please check FEN format and try again\nError code: " + ex);
					FENTextBox.Text = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq 1 0"; // resetting fen to correct format for user to copy
				}
			}
        }


        private void boardImageBox_Click(object sender, EventArgs e)
        {
			// Clearing previous clicks highlight

			// setting up vars
			MouseEventArgs click = (MouseEventArgs)e;
			Point coordinates = click.Location;
			var c_height = click.Y;
			var c_width = click.X;
			var t_height = boardImageBox.Height;
			var t_width = boardImageBox.Width;

			Console.WriteLine(coordinates);

			// work out row/col
			var row = c_height / (t_height / 8.0);
			var col = c_width / (t_width / 8.0);
			// converting to int
			int rank = (int)(row - (row % 1.0));
			int file = (int)(col - (col % 1.0));
			// outputting to console for debugging purposes
			Console.Write("Row: ");
			Console.WriteLine(rank);
			Console.Write("Col: ");
			Console.WriteLine(file);
			// Calling the highlight of the square clicked
			drawHighlights(file, rank);
		}


		private void drawHighlights(int file, int rank) 
		{
			Graphics g = Graphics.FromImage(board);
			bool isLightSquare = (file + rank) % 2 == 1;
			if (isLightSquare)
			{
				//filling in dark squares highlight
				g.FillRectangle(Brushes.SlateGray, file * 100, rank * 100, 100, 100);
			}
			else
			{
				//filling in light squares highlight
				g.FillRectangle(Brushes.LightSteelBlue, file * 100, rank * 100, 100, 100);
			}
		}

	}
}
