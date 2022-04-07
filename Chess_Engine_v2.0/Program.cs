using System;

namespace Chess_Engine_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Board board = new Board();
            board.From_FEN("pppppppp/pppppppp/8/8/8/8/PPPPPPPP/RRRRRRRR w KQkq - 0 1");
        }
    }
}
