using System;

namespace Chess_Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Board Board_State = new Board();
            Console.WriteLine("Board Internally created");
            int myNum = (int)Piece.Type.w_bishop;
            Console.WriteLine(myNum);

            FEN_Handler FEN = new FEN_Handler();
            FEN.Handler("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

        }
    }
}
