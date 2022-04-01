# IP40: The Individual Project Module (U10834)
# Chess Engine Project
## Will Castleman (wc104)

### Introduction and Idea
This project is about creating a chess engine which by the end will be able to play a respectable game of chess. It would typically be used by chess players to analyze positions for insight. It may also be used for training players up to a certain Elo rating and finally it could also just be used for a bit of fun. It will be programmed in C# and will mainly be used on a desktop computer and if there is time at the end of the project, also available to access on the web.

I chose to take on this project not only because of my interest in the game itself; but also the personal growth and development I will get out of it as a programmer. This will be one of the biggest projects I have taken on solo. I will have to deep dive into some complex search and evaluate algorithms that make up the main bulk of this project. This is not only a task well suited to computers, but these algorithms' fundamental principles could be useful in many other domains. Additionally, my time management and prioritization skills will be challenged due to the amount of different moving parts of this project.

One of the first commercially available chess engines to exist was developed by Dietrich Prinz (1951) on a Ferranti Mark 1 at University of Manchester. The Ferranti Mark 1 lacked power so it was limited in terms of the fact that it could only find the best move when a position was 2 moves away from checkmate. The next engine the world saw was by a gentleman named Bernstein (1957) which was the first complete chess engine to run on a computer (IBM 704) which could play a game from start to finish taking roughly 8 minutes to make a move. It was a type B implementation which at its core is a selective technique which attempts to cut processing times by examining variations out as far as possible and only evaluating when a reasonable amount of instability in the position has been established. It then pruned unnecessary pointless variations to further cut processing times. This is done by creating a function which evaluates the stability of the position (e.g. en prise). See Figure 1 for a “Crude definition” of what this algorithm would look like.

![Figure 1](/Write%20Up/Images/crude_definition.PNG)

A lot of people confuse these kinds of projects with implementing aspects of AI in them. Historically some of the most powerful have, for instance Google's AlphaZero, which introduced neural networks to the chess programming world. However, in this project I will not be implementing any AI aspects due to the complexity and the amount of time it would take to produce and train is just not feasible for the timescale available. Additionally, it did not align with my goals out of the project. For this project I will be using a series of algorithms which fundamentally: finds out how good the position is (an evaluation), and finds the best move in this position (a search). Essentially, it is a brute force algorithm which will filter through a given chess position and will search and evaluate it for the best move. I will go into further depth on how this would work in the project analysis section.

One of the main reasons I chose this project is not only because of the advanced understanding I will develop as a result of deep diving into researching these fundamental computing algorithms and concepts; but because of the large scope of other domains which benefit from the application of these algorithms. Examples of a few sectors which benefit from these algorithms include: finance, chemical, gaming, databases and big data, and even travel. 

### Project Links
[GITHUB](https://github.com/willcgg/Chess_Engine_Project)
[TRELLO BOARD](https://trello.com/b/KsboK28s/project-backlog)

### Project Analysis

The language I will be using to produce the engine will be C#. This is for a number of reasons such as: familiarity, portability, object-oriented nature, and finally it being a static language; this makes it easier to find errors, understand the code and also write it. C#'s main advantage is it being an object-oriented language, this makes the code highly efficient, reusable, flexible, scalable and easy to maintain. Additionally, the chess programming world is largely dominated by C and C++  languages, meaning there is a huge community of developers and resources available. Even some of the strongest engines written in other languages were eventually rewritten in C, e.g. Booot written by Alex Morozov in Delphi, it was rewritten due to running into too many 64-bit bugs. It is also commonly used for web and windows applications which fits the project's needs. 

Typically chess engines work by analyzing chess positions and then generating a list of best moves out of the possibilities. They do this by creating a table or a tree of the different possibilities in each position and evaluate which moves leave you in the best position moving forward. Take a starting chess board for example (see figure 3), for white there are 20 total possible starting moves they can take. 2 possible moves for each of the pawns and 2 for both the knights ((8x2) + (2x2) = 20) then its blacks move which has the same amount of variations as white. This means after both players make their first move there are a total of 400 different possible positional outcomes there could be. After each move there becomes more and more possibilities for where each player can move their pieces. This means the number of possible moves grows exponentially due to this, to put this into perspective see figure 4. This is why we create trees to hold all the available moves down a given path.

![Figure 2](/Write%20Up/Images/starting_pos.png)
![Figure 3](/Write%20Up/Images/ply_pos_example.PNG)

Some of the best well-known different working solutions in this area are: Stockfish, AlphaZero, Leela Chess Zero and Houdini. Each demonstrating a different approach to the classic problem. Three of these engines were written in C++ while AlphaZero was written in Python. Leela Chess Zero, much like AlphaZero, relies on AI and the use of a self taught neural network to evaluate and generate the best moves. The engine plays against itself millions of times to teach itself the best move generation. These kinds of engines focus much more on selection/evaluation to focus on the ‘winning routes’ rather than the more typical brute force search we see in solutions like Stockfish. This project will be looking into more of a brute-force type algorithm with additional refining algorithms to ‘trim’ the search down.

There are many ways to approach the board representation in this project. However,  I have chosen to represent the board in memory with the 0x12 mailbox approach. This is a 2D array of 120 length; 64 positions in the middle of the array to represent the board squares and pieces, then the remaining surrounding files and ranks represent sentinel pieces (see figure 5). I chose to do it this way rather than the traditional 8x8 approach to ensure all knight jumps, even from the very corner of the board, end in valid array positions. For example, when a knight is on square A8 it can only jump to squares B6 and B7, otherwise it would end up in positions highlighted in red squares in figure 7; and therefore off the board.  This is mainly due to the knights movement being in an L shape, see example of knights movement from a corner square in figure 7. Every move of the knight ends up with it still on a valid array index, this is useful as it will avoid errors in the engines search and evaluate algorithms where knights are positioned on bordering squares. The code will just need to check that the index the knight lands on isn’t ‘-1’ as this is a blocker piece if it is the knight cannot land there and it is not a legal move. 

![Figure 4](/Write%20Up/Images/board_array_representation.PNG)
![Figure 5](/Write%20Up/Images/array_movement_vector.PNG)
![Figure 6](/Write%20Up/Images/knight_array_movement_extreme.PNG)

Alternatives to normal FEN include: PGN, compressed FEN, ųFEN,  AND/OR custom conversion script to convert FENs to a human readable text created chess board with ascii pieces to clearly show the state to the user. This would probably be the least efficient way to go about it however it gives the project ease of readability and therefore testing will become a lot easier.

Compressed FEN could be good to save bytes and be more memory efficient in the system. However, it doesn't really meet project goals and arguably is worse for humans to read than normal FEN which is the purpose of this alternate board state storage.

ųFEN could be interesting as it considers a single square and its different states. There are a total of 14 states with the different pieces, empty squares and the blocker piece. This means the board could be represented in a total of (4bits x 64 squares) 256bits. Compared with normal FEN, which has a worst case scenario of 712 bits (r1b1k1n1/1p1p1p1p/p1p1p1p1/1n1q1b1r/R1B1P1N1/1P1P1P1P/P1P1K1P1/1N1Q1B1R w KQkq e3 999 999), almost 3 times less efficient. However in practice without compression techniques, which I do not wish to go into at the time of this project, it ends up less memory efficient than compressed FEN.

https://chess.stackexchange.com/questions/8500/alternatives-to-the-fen-notation

PGN will need to be stored anyway to complete next and back buttons functionality. This will be implemented through a stack of all the moves made in the game. Then when a user wishes to go back a position it will simply pop the top move off the stack which will be the last move played due to the stack's nature in storing data.

Development notes:
FEN validation: regex checks? TRY CATCH good enough
Look into how to get clickable pieces on the gui, need some human interaction in the program. COORDINATES CONVERTER Return square on
Click handlers?
Click boxes?
New bitmap?
New image box?

### Design

### Testing

### Conclusion

### References
Chess.com. 2022. Chess Engine | Top 10 Engines In The World. [online] Available at: <https://www.chess.com/terms/chess-engine> [Accessed 11 February 2022].
(the_real_greco), A., 2022. Understanding AlphaZero: A Basic Chess Neural Network. [online] 

Chess.com. Available at: <https://www.chess.com/blog/the_real_greco/understanding-alphazero-a-basic-chess-neural-network#:~:text=This%20just%20means%20that%20a,be%20used%20in%20an%20engine.> [Accessed 11 February 2022].

Historyofinformation.com. 2022. Alex Bernstein & Colleagues Program an IBM 704 Computer to Defeat an Inexperienced Human Opponent : History of Information. [online] Available at: <https://www.historyofinformation.com/detail.php?id=5508> [Accessed 11 February 2022].

Chessprogramming.org. 2022. Type B Strategy - Chessprogramming wiki. [online] Available at: <https://www.chessprogramming.org/Type_B_Strategy> [Accessed 11 February 2022].

En.wikipedia.org. 2022. Search algorithm - Wikipedia. [online] Available at: <https://en.wikipedia.org/wiki/Search_algorithm> [Accessed 14 February 2022].

Chessprogramming.org. 2022. Languages - Chessprogramming wiki. [online] Available at: <https://www.chessprogramming.org/Languages#:~:text=Chess%20programming%20is%20dominated%20by,bugs%20in%20the%20Delphi%20compiler.> [Accessed 14 February 2022].

Hercules, A., 2022. How Does A Chess Engine Work? A Guide To How Computers Play Chess - Hercules Chess. [online] Hercules Chess. Available at: <https://herculeschess.com/how-does-a-chess-engine-work/#:~:text=So%20how%20does%20a%20chess,with%20no%20graphics%20or%20windowing.> [Accessed 14 February 2022].

En.wikipedia.org. 2022. Forsyth–Edwards Notation - Wikipedia. [online] Available at: <https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation> [Accessed 6 March 2022].

Chessprogramming.org. 2022. 10x12 Board - Chessprogramming wiki. [online] Available at: <https://www.chessprogramming.org/10x12_Board> [Accessed 21 March 2022].
