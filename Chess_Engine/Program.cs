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
            int myNum = (int)Piece.PieceType.w_bishop;
            Console.WriteLine(myNum);

        }
    }
}
