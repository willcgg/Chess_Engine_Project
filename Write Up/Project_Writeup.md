# IP40: The Individual Project Module (U10834) <!-- omit in toc -->
# Chess Engine Project <!-- omit in toc -->
## Will Castleman (wc104) <!-- omit in toc -->

## Table Of Contents <!-- omit in toc -->
- [Introduction and Idea (5marks)](#introduction-and-idea-5marks)
  - [Background to Problem](#background-to-problem)
  - [Justification to Task](#justification-to-task)
  - [Project Links](#project-links)
- [Project Analysis (20 Marks)](#project-analysis-20-marks)
  - [Stockfish - Basics](#stockfish---basics)
  - [Stockfish - Move Generation](#stockfish---move-generation)
  - [Stockfish - Move Evaluation](#stockfish---move-evaluation)
  - [Benefits of AI Neural Networks](#benefits-of-ai-neural-networks)
  - [Implementation Anlaysis](#implementation-anlaysis)
    - [Resource Estimation](#resource-estimation)
    - [Board Representation](#board-representation)
    - [Board Notation](#board-notation)
- [Design](#design)
  - [Flow Charts](#flow-charts)
  - [Class Diagram](#class-diagram)
  - [Sequence Diagram](#sequence-diagram)
  - [Project Planning](#project-planning)
- [Testing](#testing)
- [Conclusion](#conclusion)
- [Appendix](#appendix)
- [Glossary](#glossary)
- [References](#references)

## Introduction and Idea (5marks)
### Background to Problem
This project is about creating a chess engine that by the end will be able to play a respectable game of chess. It would typically be used by chess players to analyze positions for insight. It may also be used for training players up to a certain Elo rating and finally, it could also just be used for a bit of fun. It will be programmed in C# and will mainly be used on a desktop computer and if there is time at the end of the project, also be available to access on the web.

### Justification to Task
I chose to take on this project not only because of my interest in the game itself; but also the personal growth and development I will get out of it as a programmer. This will be one of the biggest projects I have taken on solo. I will have to deep dive into some complex searches and evaluate algorithms that make up the main bulk of this project. This is not only a task well suited to computers, but these algorithms' fundamental principles could be useful in many other domains. Additionally, my time management and prioritization skills will be challenged due to the amount of different moving parts of this project.

One of the main reasons I chose this project is not only because of the advanced understanding I will develop as a result of deep-diving into researching these fundamental computing algorithms and concepts but because of the large scope of other domains which benefit from the application of these algorithms. Examples of a few sectors which benefit from these algorithms include:
- Finance
- Chemical
- Gaming
- Databases and big data
- Travel 

### Project Links
- [GITHUB](https://github.com/willcgg/Chess_Engine_Project)
- [TRELLO BOARD](https://trello.com/b/KsboK28s/project-backlog)

## Project Analysis (20 Marks)
Traditionally most chess engines follow the same blueprint:
- Finding all legal candidate moves
- Iterating through a tree of potential moves to a given depth
- Assessing the tree to find the best move

An engines quality is usually evaluated based on two criteria:
- Speed - How fast it finds a list of potential 'good' moves
- Accuracy - How fast it finds the best move out of these moves

One of the first commercially available chess engines to exist was developed by Dietrich Prinz (1951) on a Ferranti Mark 1 at the University of Manchester. The Ferranti Mark 1 lacked power so it was limited in terms of the fact that it could only find the best move when a position was 2 moves away from checkmate. The next engine the world saw was by a gentleman named Bernstein (1957) which was the first complete chess engine to run on a computer (IBM 704) which could play a game from start to finish taking roughly 8 minutes to make a move. It was a type B implementation which at its core is a selective technique that attempts to cut processing times by examining variations out as far as possible and only evaluating when a reasonable amount of instability in the position has been established. It then pruned unnecessary redundant variations to further cut processing times. This is done by creating a function that evaluates the stability of the position (e.g. en prise). See Figure 1 for a “Crude definition” of what this algorithm would look like. (Bernstein, 2022)(Chessprogramming.org. 2022)

![Figure 1](/Write%20Up/Images/crude_definition.PNG)

Figure 1: A "Crude definition" of an en prise algorithm

Since then engines have developed significantly with engines such as:
- AlphaZero
- Stockfish
- Leela Chess Zero
- Houdini

Each demonstrates a different approach to the classic problem. Three of these engines were written in C++ while AlphaZero was written in Python. Leela Chess Zero, much like AlphaZero, relies on AI and the use of a self-taught neural network to evaluate and generate the best moves. The engine plays against itself millions of times to teach itself the best move generation. These kinds of engines focus much more on selection/evaluation to focus on the ‘winning routes’ rather than the more typical brute force search we see in solutions like Stockfish. This project will be looking into more of a brute-force type algorithm with additional refining algorithms to ‘trim’ the search down. (Chess Engine | Top 10 Engines In The World, 2022)

### Stockfish - Basics
Stockfish, one of the most powerful and well-known engines available to the public, was developed over several decades with the input from several chess grandmasters and many other sources. It used to be a classical brute force style implementation analyzing millions of positions per second for the optimal move; which was defined by countless human input. However, since the famous loss against AlphaZero spoke about below they implemented aspects of AI and machine learning to further enhance the engine and cut processing times. (Champion, 2022)

Stockfish works by storing the board in a bitboard fashion, the board is made up of 64 bits with 1 bit representing a square on the board (see figure 2); if the bit is set to 1 it is occupied with a piece. This way it is easy to represent when a piece is moved through bitwise operations:
- One square forward: left shift of 8 bits
- One square left: left shift of 1 bit
- Retrieving all pieces currently on board: Logical OR of all the individual bitboards together
- Checking if a square is occupied: Logical AND of the bitboards with the positional mask of the selected square
- E.t.c...

![Figure 2](./images/little_endian_representation.PNG)

Figure 2: Little-Endian File-Rank Mapping

### Stockfish - Move Generation
Next, I will go over how the engine generates its list of candidate moves. Some pieces, for example, the knight, have fixed candidate moves due to the way they move; that being in an 'L' shape, with three squares forward and one square left (see Figure 3). (Champion, 2022)

![Figure 3](https://miro.medium.com/max/412/1*sEZ4IjrU8g81anHKq74Clg.png)

Figure 3: Knight piece movement example

Bitshift operations are stored for knights movement, these contain all eight operations required to move the knight in any of its directions. This works for most knight movements except for those where it is near a side of the board in which a mask is applied to ensure that no moves where the piece ends up off the board are generated. To accomplish this a safe destination method is run after generating all pseudo-legal candidate moves to eliminate those that are invalid off-board positions. Pseudo legal move generators simply look for all empty square moves possible given a board position, it ignores most scenarios listed below; once the moves have been generated it then runs a 'bool Position::legal(move m)' method alongside 'position.cpp' which tests whether the moves generated are indeed legal. (Champion, 2022) The method checks for scenarios such as:
- Blocking pieces
- Discovered checks
- Pinned pieces
- E.t.c..

For the other sliding pieces such as rooks, bishops and the queen candidate moves are a little bit more problematic to find due to the sliding nature of the pieces' movement; they can move an indefinite amount of squares in their available attacking rays depending on whether a piece is blocking. To accomplish move generation of these pieces a combination of the chosen pieces attacking rays and the complete board representation need to be AND'd together to find these blocking pieces (see figure 4). Although this can be done on the fly for each piece and each attacking ray direction they can move, it is computationally expensive to do so. Therefore Stockfish uses a slightly more efficient way of doing so by using the look-up method in an array containing all the candidate moves for the sliding piece. However, finding all blockers for the piece is still required.(Champion, 2022)

![Figure 4](https://miro.medium.com/max/1114/1*3pr2KR7a5ATzHT8gizWABQ.png)

Figure 4: Sliding piece move generation; blocking pieces

Once the blockers have been found, Stockfish uses this blockers board combined with the existing array containing the candidate moves to generate the actual candidate moves for the piece (see figure 5 below).

![Figure 5](https://miro.medium.com/max/812/1*0aczfRzfKOceRX7nlaDcoA.png)

Figure 5: Finding legal candidate moves for sliding pieces

However, with this method comes a problem due to the blocker piece board being a 64-bit array the array containing the candidate moves will have up to 2<sup>64</sup> elements contained; this works out at about one exabyte in size which is much larger than any modern memory can hold at once. To solve this issue Stockfish uses a hashmap to store the candidate moves more memory efficiently. This brings the candidate move array down to only a few hundred kilobytes; easily handled by most modern computer systems. For a diagrammatic summary of all described above see figure 6. (Champion, 2022)

![Figure 6](https://miro.medium.com/max/1400/1*FbSMy5L6nkJqATgI9bTm5g.png)

Figure 6: Summary of Stockfishes process to generating a move list

### Stockfish - Move Evaluation
Once Stockfish has generated its set of possible legal moves it needs to evaluate to return the best possible move for this set. Until 2018 when Stockfish was drastically outperformed by AlphaZero, spoken about below, Stockfish relied solely on a classical evaluation of the position to retrieve the best move. Since then, they have integrated a neural network to assist in evaluations of more balanced positions to close the gap. For this next section, I will be focusing more on the classical evaluation and later look into the benefits brought by AI.

Without neural networks, Stockfishe's classical evaluation simply relies on pro chess concepts such as:
- Tempo
- Material
- Space e.t.c

The evaluation function is essentially a combination of chess concepts and strategies input by chess professionals and Grandmasters over several decades. It essentially evaluates things such as but not limited to the following parts along with examples:
- Material:
    - Imbalance - How many pieces left
    - Advantage - Strength of pieces e.g. bishop pair
- Strategy
    - Advantage for pawns e.g. - Doubled pawns, isolated pawns, connected pawns, supported pawn structure, attacked pawns e.t.c
    - Advantage for pieces e.g. - Blocked pieces, bishop x-ray attacks, bishops on long diagonals such as C4 for light-squared bishop, trapping pieces, rook, and queen battery, keeping rooks on open files, forking pieces, e.t.c
- Space - Controlling more squares than the opponent
- King Safety - Looking out for incoming checks, keeping king 'sheltered' e.g. castling

This is the main bulk of what makes up these engines and what differentiates them from others; it essentially makes up the 'personality' of the engine and how it plays. Due to Stockfish's open-source nature, there have been countless pull requests with just the editing of some of the weights and scores of these functions which entails small elo rating improvements. (Champion, 2022)

### Benefits of AI Neural Networks
Historically some of the most powerful engines have implemented aspects of AI, for instance, Google's AlphaZero, which introduced neural networks to the chess programming world. AI demonstrated its supremacy over other engines when it came out victorious in its hundred-game match against the well-known Stockfish 8, which at the time of playing this match could beat even the top players in the world. This match-up was played with three hours of playtime with a 15-second increment meaning there was plenty of time for both engines to evaluate positions thoroughly to the best of their abilities and makes any arguments of time limitations playing to either of the engine's disadvantage obsolete. (Pete, 2022)

AlphaZero even soundly won against the traditional engine in a series of time-odds matchups with an astounding time odds of 10:1; meaning that AlphaZero even won with ten times less time than that of Stockfish (see figure 4). Furthermore, to take it further the machine-learning engine even won matchups with a version of Stockfish with a "strong opening book". It did win a substantial amount more games when AlphaZero was playing as black however not nearly enough to win the overall match (see Figure 5 for results). These victories over the strongest of traditional chess engines show just how powerful AI can be in both:
- Evaluating moves
- Searching for moves

DeepMind released information suggesting AlphaZero uses a Monte Carlo tree search algorithm to examine around 60,000 positions per second compared to Stockfishes 60 million per second; demonstrating its much higher efficiency in generating its move set. (Pete, 2022)

![Figure 7](https://images.chesscomfiles.com/uploads/v1/images_users/tiny_mce/pete/phponPJMm.png)

Figure 7: AlphaZero's results in time odds match against Stockfish engine

![Figure 8](https://images.chesscomfiles.com/uploads/v1/images_users/tiny_mce/pete/php3NK0bQ.png)

Figure 8: AlphaZero's match-up results against Stockfish with a "strong opening book". Image by DeepMind.

These results safely conclude that AI and machine learning are superior to traditional engines and have solidified their place in the game and engines today. (Pete, 2022)

### Implementation Anlaysis

#### Resource Estimation
Take a starting chess board for example (see figure 9), for white there are 20 total possible starting moves they can take. 2 possible moves for each of the pawns and 2 for both the knights ((8x2) + (2x2) = 20) then its blacks move which has the same amount of variations as white. This means after both players make their first move there are a total of 400 different possible positional outcomes. 

![Figure 9](/Write%20Up/Images/starting_pos.png)

Figure 9: Starting chess position

After each move there becomes more and more possibilities for where each player can move their pieces. This means the number of possible positions grows exponentially due to this, to put this into perspective see figure 10. This is why we create trees to hold all the available moves down a given path.( Hercules, A., 2022)

![Figure 10](/Write%20Up/Images/ply_pos_example.PNG)

Figure 10: Number of variations with incrementing the half-ply count

#### Board Representation
There are many ways to approach the board representation in this project such as:
- Piece Centric
  - Piece-Lists
  - Piece-Sets
  - Bitboards

These types of implementations typically hold a collection of pieces still on the board with information such as square occupied; they are typically held in lists or arrays. Doing it this way comes with the benefit of avoiding scanning the board for move generation purposes saving processing time.
- Square Centric
  - Mailbox Approach
    - 8x8 Board
    - 10x12 Board
    - Vector attacks
    - 0x88

These types of implementations typically hold the opposite of piece-centric approaches in the way they hold pieces of information on squares on the board. For example, an array of all the squares on the board is created and will hold information on whether there is a piece occupying it or if it's empty. 

- Hybrid Solutions

 As spoken briefly about above, some of these types of implementations may also use elements of both of these types of implementation hence the 'hybrid'. Different search and evaluate functions tend to favor a specific representation; however, it is still quite common to see both in solutions produced today. 

However,  I have chosen to represent the board in memory with the 0x12 mailbox approach. This is a 2D array of 120 slots in size; 64 positions in the middle of the array represent the board squares and pieces, then the remaining surrounding files and ranks represent sentinel pieces (see figure 11). I chose to do it this way rather than the traditional 8x8 approach to ensure all knight jumps, even from the very corner of the board, end up on valid array positions. For example, when a knight is on square A8 it can only jump to squares B6 and B7, otherwise, it would end up in positions highlighted in red squares in figure 12; and therefore not on the board. Every move of the knight ends up with it still on a valid array index, this is useful as it will avoid errors in the engine's search and evaluate algorithms where knights are positioned on bordering squares. The code will just need to check that the index the knight lands on isn’t ‘-1’ as this is a blocker piece if it is the knight cannot land there and it is not a legal move. (Chessprogramming.org. 2022)

![Figure 11](/Write%20Up/Images/board_array_representation.PNG)
![Figure 12](/Write%20Up/Images/knight_array_movement_extreme.PNG)
![Figure 13](/Write%20Up/Images/array_movement_vector.PNG)

#### Board Notation
Alternatives to normal FEN include PGN, compressed FEN, ųFEN,  AND/OR custom conversion script to convert FENs to a human-readable text created chessboard with ASCII pieces to clearly show the state to the user. This would probably be the least efficient way to go about it however it gives the project ease of readability and therefore testing will become a lot easier.

Compressed FEN could be good to save bytes and be more memory efficient in the system. However, it doesn't meet project goals and arguably is worse for humans to read than normal FEN which is the purpose of this alternate board state storage.

https://www.chessprogramming.org/Transposition_Table

ųFEN could be interesting as it considers a single square and its different states. There are a total of 14 states with the different pieces, empty squares, and the blocker piece. This means the board could be represented in a total of (4bits x 64 squares) 256bits. Compared with normal FEN, which has a worst-case scenario of 712 bits (r1b1k1n1/1p1p1p1p/p1p1p1p1/1n1q1b1r/R1B1P1N1/1P1P1P1P/P1P1K1P1/1N1Q1B1R w KQkq e3 999 999), almost 3 times less efficient. However, in practice without compression techniques, which I do not wish to go into at the time of this project, it ends up less memory efficient than compressed FEN.

https://chess.stackexchange.com/questions/8500/alternatives-to-the-fen-notation

PGN will need to be stored anyway to complete the functionality of the next and back buttons. This will be implemented through a stack of all the moves made in the game. Then when a user wishes to go back a position it will simply pop the top move off of the stack which will be the last move played due to the stack's nature in storing data.

## Design
The language I will be using to produce the engine will be C#. This is for several reasons such as familiarity, portability, object-oriented nature, and finally, it is a static language; this makes it easier to find errors, understand the code and also write it. C#'s main advantage is it is an object-oriented language, this makes the code highly efficient, reusable, flexible, scalable, and easy to maintain. Additionally, the chess programming world is largely dominated by C and C++  languages, meaning there is a huge community of developers and resources available. Even some of the strongest engines written in other languages were eventually rewritten in C, e.g. Booot written by Alex Morozov in Delphi, it was rewritten due to running into too many 64-bit bugs. It is also commonly used for web and windows applications which fits the project's needs. 

### Flow Charts

### Class Diagram

classDiagram
    Board --> Piece : Contains
    Board --> FEN_Handler : Utilises
    Board --> Move : Utilises
    Board --> Psuedo_Move_Generation : Utilises
    Board --> Legal_Move_Generation : Utilises
    Board --> Move_Evaluation : Utilises
    Psuedo_Move_Generation --> Transposition_Table : Utilises
    Legal_Move_Generation --> Transposition_Table : Utilises
   
    class Board{
      +int[] board
      +enum squares
      +bool white_king_castle
      +bool white_queen_castle
      +bool black_king_castle
      +bool black_queen_castle
      +string side_to_move
      +string FEN_Input
      +string FEN_Default
      +int en_passant_target
      +int half-ply
      +int full-ply
      +list move_history
      Initialise_Board()
      Load_From_FEN()
      Make_Move()
      Unmake_Move()
    }
    class Piece{
      +enum Type
      +int[] w_pawn_offsets
      +int[] b_pawn_offsets
      +int[] bishop_offsets
      +int[] knight_offsets
      +int[] rook_offsets
      +int[] k_q_offsets
    }
    class FEN_Handler{
        +string[] FEN_Segments
        +string[] FEN_Position
        Convert_FEN()
        Set_Castle_Rights()
        Create_Board()
        Convert_From_ASCII()
    }
    class Psuedo_Move_Generation{
        +list moves
        +bool in_check
        +bool pinned
        +bool b_q_castle_rights
        +bool b_k_castle_rights
        +bool w_q_castle_rights
        +bool w_k_castle_rights
        +string side_to_move
        +string opponent_colour
        +int friendly_king_pos
        +int opponent_king_pos
        Generate_Moves_List()
        Generate_Sliding_Moves()
        Generate_King_Moves()
        Generate_Knight_Moves()
        Generate_Pawn_Moves()
        In_Check()
        Pinned()
        Promotion_Moves()
    }
    class Legal_Move_Generation{
        +list moves
        +bool in_check
        +bool pinned
        +bool b_q_castle_rights
        +bool b_k_castle_rights
        +bool w_q_castle_rights
        +bool w_k_castle_rights
        +string side_to_move
        +string opponent_colour
        +int friendly_king_pos
        +int opponent_king_pos
        Filter_Moves_List()
    }
    class Move_Evaluation{

    }
    class Transposition_Table{
        +Hashtable transposition_table
    }
    class Move{
        +int start_square
        +int target_square
    }
[![](https://mermaid.ink/img/pako:eNrtVk1v2zAM_SuCTxvW_oEcBmzpV7B2CJb2tAwCYzOxYFlyJblBEPS_j5JTx3LsdAN2XE7Be4-yyEea3iepzjCZJKkEa68EbAyUS8Xo91WDydjl5Wc2F5gim7CpVg6Esn3-5vo7vwOVSTSkenJCCosnqgf9gmfoua0x09yr-C0qNOCEVmcC7nED8i_0QXn9ArIeVo5cwIc-GlC20lZ4hD_CSp5mMnydP4xujggeNDfeNwhjn4RyP3-xlQdbDFVdMvtcg3l7OoErrSXb5sIhL4Ta8BSskzhEP9eIapBfSUiL8fCGHgy3zlAUsyJD7jQvqQ59zrfJTFW1GyKucA21dN20GT2looqActyB2WDM5iDXl5XcReC6ljICqcaO-dvwnP5p0zIzRX6At4CHin_4-Mbca8j4jdElp4sd4QcoMPh7hJ5U2Qdfu1aGwdnHtj3uKuyZu6U0t4rr9dqis33nz5LC5roaIQslNrkbIY3WxVgcf46ZKKfOsLeZtVZStOcXuClRHQ_u8_PDMBx5erW8oHFxxRlboOPT0Gj8h0_GdsmpQXAn7nXO8hZ-WUxns2FzBue9m1PbO91EwiAI6v8c06KPV0IpzProigrajAs3IYtTQXFesH3vhO2ZE86M5pHVVaUVecZTLXVtOoIwVkYgWb5rXg30LuvxbfQpfyhtMyWW31NNu2a19EKKzAcH2aDi2zt00-7jgrmfoxN6pvjUW9nF5sHGCKFe0uH9HR0QNdTgBvjfT_-4n26EdGgGuinyorfsyYUB0cBi7tp1BzZ3YVu7SBiwkWfue4lYWlyON6u6RzUrLeJek4ukRFOCyOiTLJy1TFyOJS6TCf3NDksyWSovrauM-vo6E7TXkskapMWLBGqnFzuVJhNnanwTHb7sDqrX31I2M6U)](https://mermaid.live/edit#pako:eNrtVk1v2zAM_SuCTxvW_oEcBmzpV7B2CJb2tAwCYzOxYFlyJblBEPS_j5JTx3LsdAN2XE7Be4-yyEea3iepzjCZJKkEa68EbAyUS8Xo91WDydjl5Wc2F5gim7CpVg6Esn3-5vo7vwOVSTSkenJCCosnqgf9gmfoua0x09yr-C0qNOCEVmcC7nED8i_0QXn9ArIeVo5cwIc-GlC20lZ4hD_CSp5mMnydP4xujggeNDfeNwhjn4RyP3-xlQdbDFVdMvtcg3l7OoErrSXb5sIhL4Ta8BSskzhEP9eIapBfSUiL8fCGHgy3zlAUsyJD7jQvqQ59zrfJTFW1GyKucA21dN20GT2looqActyB2WDM5iDXl5XcReC6ljICqcaO-dvwnP5p0zIzRX6At4CHin_4-Mbca8j4jdElp4sd4QcoMPh7hJ5U2Qdfu1aGwdnHtj3uKuyZu6U0t4rr9dqis33nz5LC5roaIQslNrkbIY3WxVgcf46ZKKfOsLeZtVZStOcXuClRHQ_u8_PDMBx5erW8oHFxxRlboOPT0Gj8h0_GdsmpQXAn7nXO8hZ-WUxns2FzBue9m1PbO91EwiAI6v8c06KPV0IpzProigrajAs3IYtTQXFesH3vhO2ZE86M5pHVVaUVecZTLXVtOoIwVkYgWb5rXg30LuvxbfQpfyhtMyWW31NNu2a19EKKzAcH2aDi2zt00-7jgrmfoxN6pvjUW9nF5sHGCKFe0uH9HR0QNdTgBvjfT_-4n26EdGgGuinyorfsyYUB0cBi7tp1BzZ3YVu7SBiwkWfue4lYWlyON6u6RzUrLeJek4ukRFOCyOiTLJy1TFyOJS6TCf3NDksyWSovrauM-vo6E7TXkskapMWLBGqnFzuVJhNnanwTHb7sDqrX31I2M6U)

### Sequence Diagram

### Project Planning

## Testing

## Conclusion 

## Appendix

## Glossary
Key:

Word - Meaning

Transposition - A transposition in chess is a sequence of moves that results in a position which may also be reached by another sequence of moves. For instance 1. d4 e6 2. e4 versus 1. e4 e6 2. d4, or {6. cxd4 exd4 7. exd4} versus {6. exd4 exd4 7. cxd4}. At least two moves (three plies) are necessary to transpose by exchanging moves, the more plies, the more possible sequences with transpositions are possible. https://www.chessprogramming.org/Transposition

## References 
Chess.com. 2022. Chess Engine | Top 10 Engines In The World. [online] Available at: <https://www.chess.com/terms/chess-engine> [Accessed 11 February 2022].
(the_real_greco), A., 2022. Understanding AlphaZero: A Basic Chess Neural Network. [online] 

Chess.com. Available at: <https://www.chess.com/blog/the_real_greco/understanding-alphazero-a-basic-chess-neural-network#:~:text=This%20just%20means%20that%20a,be%20used%20in%20an%20engine.> [Accessed 11 February 2022].

Historyofinformation.com. 2022. Alex Bernstein & Colleagues Program an IBM 704 Computer to Defeat an Inexperienced Human Opponent : History of Information. [online] Available at: <https://www.historyofinformation.com/detail.php?id=5508> [Accessed 11 February 2022].

Chessprogramming.org. 2022. Type B Strategy - Chessprogramming wiki. [online] Available at: <https://www.chessprogramming.org/Type_B_Strategy> [Accessed 11 February 2022].

Chessprogramming.org. 2022. Languages - Chessprogramming wiki. [online] Available at: <https://www.chessprogramming.org/Languages#:~:text=Chess%20programming%20is%20dominated%20by,bugs%20in%20the%20Delphi%20compiler.> [Accessed 14 February 2022].

Hercules, A., 2022. How Does A Chess Engine Work? A Guide To How Computers Play Chess - Hercules Chess. [online] Hercules Chess. Available at: <https://herculeschess.com/how-does-a-chess-engine-work/#:~:text=So%20how%20does%20a%20chess,with%20no%20graphics%20or%20windowing.> [Accessed 14 February 2022].

En.wikipedia.org. 2022. Forsyth–Edwards Notation - Wikipedia. [online] Available at: <https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation> [Accessed 6 March 2022].

Chessprogramming.org. 2022. 10x12 Board - Chessprogramming wiki. [online] Available at: <https://www.chessprogramming.org/10x12_Board> [Accessed 21 March 2022].

Champion, A., 2022. Dissecting Stockfish Part 1: In-Depth look at a chess engine. [online] Medium. Available at: <https://towardsdatascience.com/dissecting-stockfish-part-1-in-depth-look-at-a-chess-engine-7fddd1d83579#:~:text=Stockfish%20is%20actually%20performing%20the,blocking%20pieces%20or%20discovered%20checks.> [Accessed 29 April 2022].

Champion, A., 2022. Dissecting Stockfish Part 2: In-Depth look at a chess engine. [online] Medium. Available at: <https://towardsdatascience.com/dissecting-stockfish-part-2-in-depth-look-at-a-chess-engine-2643cdc35c9a> [Accessed 29 April 2022].

(Pete), P., 2022. AlphaZero Crushes Stockfish In New 1,000-Game Match. [online] Chess.com. Available at: <https://www.chess.com/news/view/updated-alphazero-crushes-stockfish-in-new-1-000-game-match#games> [Accessed 29 April 2022].
