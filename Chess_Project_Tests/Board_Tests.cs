﻿using Chess_Engine;

namespace Chess_Project_Tests
{
    [TestClass]
    class Board_Tests
    {

        [TestMethod]
        public void FEN_Handler_Tests()
        {
            // Arrange
            FEN_Handler_Tests ft = new FEN_Handler_Tests();

            // Act & Assert
            ft.FEN_Handler_Default();
            ft.FEN_Handler_Custom();
        }

    }
}
