using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_Engine_v2;

namespace Chess_Engine_Tests
{
    /// <summary>
    /// <para>Checks all possible rook movements</para>
    /// <para>e.g. Castling, pinned, blocking pieces e.t.c.</para>
    /// </summary>
    [TestClass]
    public class Rook_Tests
    {
        Board board;

        [TestMethod]
        public void Movement_Valid()
        {
            //  arrange
            board = new Board();

            //  act

            //  assert
        }

        [TestMethod]
        public void Movement_Castle_Tests()
        {
            //  arrange
            board = new Board();

            //  act

            //  assert
        }

        [TestMethod]
        public void Movement_in_Check()
        {
            //  arrange
            board = new Board();

            //  act

            //  assert
        }

        [TestMethod]
        public void Movement_Pinned()
        {
            //  arrange
            board = new Board();

            //  act

            //  assert
        }
    }
}
