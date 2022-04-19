using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;

namespace Chess_Engine_Tests
{
    /// <summary>
    /// <para>Checks all possible bishop movements</para>
    /// </summary>
    [TestClass]
    public class Bishop_Tests
    {
        Board b;

        [TestMethod]
        public void Movement_Valid_Forward()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^♟^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^♙^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act

            // assert
        }

        [TestMethod]
        public void Movement_in_Check()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^♟^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^♙^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act

            // assert
        }

        [TestMethod]
        public void Movement_Pinned()
        {
            //  arrange
            string board = @"^^^^^^^^
                            ^♟^^^^^^
                            ^^^^^^^^
                            ♙^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^
                            ^^^^^^^^";
            string board_final = @"^^^^^^^^
                                ^^^^^^^^
                                ^♙^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^
                                ^^^^^^^^";
            b = new Board();
            b.board = b.Convert_From_ASCII(board);

            //  act

            // assert
        }
    }
}
