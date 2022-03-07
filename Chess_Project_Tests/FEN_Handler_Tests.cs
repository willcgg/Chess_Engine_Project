namespace Chess_Project_Tests
{
    [TestClass]
    class FEN_Handler_Tests
    {
        /// <summary>
        /// Method to test the default board position along with its attributes
        /// </summary>
        [TestMethod]
        public void FEN_Handler_Default()
        {
            // Arrange
            // Initialising Test Var's      Setting them to what they should be on starting board position
            int[120] default_board = {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,               //  This is what the board array should look like
                                      -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,               //  on default starting posistion
                                      -1, 8, 4, 6, 10, 12, 6, 4, 8, -1,
                                      -1, 2, 2, 2, 2, 2, 2, 2, 2, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 1, 1, 1, 1, 1, 1, 1, 1, -1,
                                      -1, 7, 3, 5, 9, 11, 5, 3, 7, -1,
                                      -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                      -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
            string en_passant_target = "-";
            int half_ply = "1";
            int full_ply = "0";
            bool w_k_castle = true;
            bool w_q_castle = true;
            bool b_k_castle = true;
            bool b_q_castle = true;
            char side_to_move = 'w';

            // Act
            // Creating board object to test
            Board b_test = new Board();

            // Assert
            Assert.True(b_test.board == default_board);
            Assert.True(b_test.en_passant_target == en_passant_target);
            Assert.True(b_test.half_ply == half_ply);
            Assert.True(b_test.full_ply == full_ply);
            Assert.True(b_test.w_k_castle == w_k_castle);
            Assert.True(b_test.w_q_castle == w_q_castle);
            Assert.True(b_test.b_k_castle == b_k_castle);
            Assert.True(b_test.b_q_castle == b_q_castle);
            Assert.True(b_test.side_to_move == side_to_move);
        }

        /// <summary>
        /// Method to test a custom board position along with its attributes
        /// </summary>
        [TestMethod]
        public void FEN_Handler_Custom()
        {
            // Arrange
            // Initialising Test Var's      Setting them to what they should be on starting board position
            int[120] default_board = {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,               //  This is what the board array should look like
                                      -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,               //  on default starting posistion
                                      -1, 2, 2, 2, 2, 2, 2, 2, 2, -1,
                                      -1, 2, 2, 2, 2, 2, 2, 2, 2, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 0, 0, 0, 0, 0, 0, 0, 0, -1,
                                      -1, 1, 1, 1, 1, 1, 1, 1, 1, -1,
                                      -1, 1, 1, 1, 1, 1, 1, 1, 1, -1,
                                      -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                                      -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
            string en_passant_target = "e7";
            int half_ply = "28";
            int full_ply = "14";
            bool w_k_castle = false ;
            bool w_q_castle = true;
            bool b_k_castle = true;
            bool b_q_castle = false;
            char side_to_move = 'b';

            // Act
            // Creating board object to test
            Board b_test = new Board();
            b_test.From_FEN("pppppppp/pppppppp/8/8/8/8/PPPPPPPP/PPPPPPPP b Qk e7 28 14");       // tests all aspects of FEN_Handler
                                                                                                // {Pos, side, castle, en-passant, half, full-ply}

            // Assert
            Assert.True(b_test.board == default_board);
            Assert.True(b_test.en_passant_target == en_passant_target);
            Assert.True(b_test.half_ply == half_ply);
            Assert.True(b_test.full_ply == full_ply);
            Assert.True(b_test.w_k_castle == w_k_castle);
            Assert.True(b_test.w_q_castle == w_q_castle);
            Assert.True(b_test.b_k_castle == b_k_castle);
            Assert.True(b_test.b_q_castle == b_q_castle);
            Assert.True(b_test.side_to_move == side_to_move);
        }


    }
}
