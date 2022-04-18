using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Chess_Engine_v2;

namespace Chess_Engine_Project
{
    /// <summary>
    /// Class to display the board and its pieces to the user and also handle all form controls.
    /// </summary>
    public partial class BoardUI : Form
    {

		Bitmap board;
        readonly Board b;

		public BoardUI()
        {
            InitializeComponent();
			board = new Bitmap(800, 800);
			b = new Board();
		}

        private void BoardUI_Load(object sender, EventArgs e)
        {
			DrawBoardToScreen();
		}

		public void DrawBoardToScreen()
		{
			Graphics g = Graphics.FromImage(board);

			// draw board
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
			BoardPictureBox.Image = board;
			// draw pieces
			DrawPiecesToBoard(b);
		}

        private void FENGenerateButton_Click(object sender, EventArgs e)
        {
			// Error checking
			if (FENTextBox.Text == "")
			{
				MessageBox.Show("Please enter a valid FEN string.\n\tFormat: e.g. rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq 0 1");
			}
			else
            {
				// Try run it through the engine FEN_Handler, if it creates error then do not accept the FEN
				try
				{
					// create board in engines memory
					FEN_Handler handler = new FEN_Handler(FENTextBox.Text, b);
					// draw new board to GUI
					DrawBoardToScreen();
					// write board to text file for use in testing
					string ASCII_board = handler.Convert_To_ASCII();
					File.WriteAllText("C:/Users/wc104/source/repos/Chess_Engine_Project/board.txt", ASCII_board);
				}
				catch (Exception ex) 
				{
					MessageBox.Show("Error creating board from FEN, please check FEN format matches below example and try again\n\n" +
						"\"{POSITION} {SIDE TO MOVE} {CASTLE AVAILABILITY} {EN-PASSANT TARGET} {HALF-PLY} {FULL-PLY}\"" +
						"\n\nError code: " + ex);
					FENTextBox.Text = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"; // resetting fen to correct format for user to copy
				}
			}
        }

		public void DrawPiecesToBoard(Board b)
		{
			// init vars
			Brush brush;
			string current_piece = "";
			Graphics g = Graphics.FromImage(board);
			Font font = new Font("UTF-8", 52);
			int file = 0;
			int rank = 0;

			// loop through board array
			for (int x = 21; x < 99; x++)
			{
				// selecting brush colour 
				if (b.board[x] == 1 || b.board[x] == 3 || b.board[x] == 5 || b.board[x] == 7 ||
					b.board[x] == 9 || b.board[x] == 11)
				{
					// piece is white
					brush = Brushes.White;
				}
				else
					brush = Brushes.Black;

				// finding what piece it is then drawing to board
				switch(b.board[x])
                {
					case -1:
						// blocker piece
						current_piece = "";
						break;
					case 0:
						// empty square
						current_piece = "";
						break;
					case 1:
						// white pawn
						current_piece = "♙";
						break;
					case 2:
						// black pawn
						current_piece = "♟";
						break;
					case 3:
						// white knight
						current_piece = "♘";
						break;
					case 4:
						current_piece = "♞";
						break;
					case 5:
						current_piece = "♗";
						break;
					case 6:
						current_piece = "♝";
						break;
					case 7:
						current_piece = "♖";
						break;
					case 8:
						current_piece = "♜";
						break;
					case 9:
						current_piece = "♕";
						break;
					case 10:
						current_piece = "♛";
						break;
					case 11:
						current_piece = "♔";
						break;
					case 12:
						current_piece = "♚";
						break;
				}

				g.DrawString(current_piece, font, brush, file*100, rank*100);

				// incrementing vars
				if(b.board[x] != -1)
                {
					file++;
                }
				if (file > 0 && file % 8 == 0){
					file = 0;
					rank++;
				}
			}
		}


		private void BoardPictureBox_Click(object sender, EventArgs e)
        {
			// Clearing previous clicks highlight

			// setting up vars
			MouseEventArgs click = (MouseEventArgs)e;
			Point coordinates = click.Location;
			var c_height = click.Y;
			var c_width = click.X;
			var t_height = BoardPictureBox.Height;
			var t_width = BoardPictureBox.Width;

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
			DrawHighlights(file, rank);
		}


		private void DrawHighlights(int file, int rank) 
		{
			// copying current board bitmap (should be clear)
			Bitmap board_ps = board.Clone() as Bitmap;
			// Drawing highlight
			//--------------------
			Graphics g = Graphics.FromImage(board_ps);
			Pen pen = new Pen(Color.Turquoise, 5);
			// Create rectangle.
			Rectangle rect = new Rectangle(file * 100, rank * 100, 100, 100);
			// Draw rectangle to screen.
			g.DrawRectangle(pen, rect);
			BoardPictureBox.Image = board_ps;
		}

	}
}
