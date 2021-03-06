using System;
using System.Collections.Generic;
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
				if (b.board[x] == (int)Piece.Type.w_bishop || b.board[x] == (int)Piece.Type.w_king || b.board[x] == (int)Piece.Type.w_knight 
					|| b.board[x] == (int)Piece.Type.w_pawn || b.board[x] == (int)Piece.Type.w_queen || b.board[x] == (int)Piece.Type.w_rook)
				{
					// piece is white
					brush = Brushes.Black;
				}
				else
					brush = Brushes.White;

				// finding what piece it is then drawing to board
				switch(b.board[x])
                {
					case (int)Piece.Type.blockerPiece:
						// blocker piece
						current_piece = "";
						break;
					case (int)Piece.Type.empty:
						// empty square
						current_piece = "";
						break;
					case (int)Piece.Type.b_pawn:
						// white pawn
						current_piece = "♙";
						break;
					case (int)Piece.Type.w_pawn:
						// black pawn
						current_piece = "♟";
						break;
					case (int)Piece.Type.b_knight:
						// white knight
						current_piece = "♘";
						break;
					case (int)Piece.Type.w_knight:
						current_piece = "♞";
						break;
					case (int)Piece.Type.b_bishop:
						current_piece = "♗";
						break;
					case (int)Piece.Type.w_bishop:
						current_piece = "♝";
						break;
					case (int)Piece.Type.b_rook:
						current_piece = "♖";
						break;
					case (int)Piece.Type.w_rook:
						current_piece = "♜";
						break;
					case (int)Piece.Type.b_queen:
						current_piece = "♕";
						break;
					case (int)Piece.Type.w_queen:
						current_piece = "♛";
						break;
					case (int)Piece.Type.b_king:
						current_piece = "♔";
						break;
					case (int)Piece.Type.w_king:
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
			// init 
			Piece.Type piece;
			// setting up vars
			MouseEventArgs click = (MouseEventArgs)e;
			var c_height = click.Y;
			var c_width = click.X;
			var t_height = BoardPictureBox.Height;
			var t_width = BoardPictureBox.Width;
			var square = "";
			// work out row/col
			var row = c_height / (t_height / 8.0);
			var col = c_width / (t_width / 8.0);
			// converting to int
			int rank = (int)(row - (row % 1.0));
			int file = (int)(col - (col % 1.0));
			// convert to board square
			if (file == 0)
				square += "a" + (rank + 1);
			else if(file == 1)
				square += "b" + (rank + 1);
			else if(file == 2)
				square += "c" + (rank + 1);
			else if(file == 3)
				square += "d" + (rank + 1);
			else if(file == 4)
				square += "e" + (rank + 1);
			else if(file == 5)
				square += "f" + (rank + 1);
			else if(file == 6)
				square += "g" + (rank + 1);
			else if(file == 7)
				square += "h" + (rank + 1);
			// Retrieving piece clicked
			piece = (Piece.Type)b.Get_Piece_From_Square(square);
			Console.WriteLine(piece);
			// Calling the highlight of the square clicked
			DrawSquareHighlight(file, rank);
			// Calling valid move highlights for selected piece
			DrawValidMoveHighlight(piece, square);
		}


		private void DrawSquareHighlight(int file, int rank) 
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

		private void DrawValidMoveHighlight(Piece.Type p, string start_square)
        {
			// init
			Piece.Type piece = p;
			List<int> valid_moves = new List<int>();
			// copying current board bitmap (with piece highlighted)
			Bitmap board_ps = (Bitmap)BoardPictureBox.Image;
			// Drawing highlight
			//--------------------
			Graphics g = Graphics.FromImage(board_ps);
			Pen pen = new Pen(Color.Green, 5);
			//Find Pieces Valid Moves
			valid_moves = b.Get_Valid_Moves(piece, start_square);
		}

    }
}
