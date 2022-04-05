
# Project Notes

## SUPERVISOR MEETING 13/01/2022 @10-10:45am

### Action Points:

- Focus on creating Poster for now
- Maybe implement some kind of interactivity to project to demonstrate in the presentation
- Keep meeting minutes and log notes of supervisor meetings

### Notes from meeting:

1. Discussed audience for presentation.
2. Discussed booking hour long meeting for in person to define marking criteria and other details.
3. Discussed Testing strategies, ie unit testing framework. Do some research into this for c# in visual studio. This will help me to visualize what actually needs to be done for each method abd speed up development by saving manually testing each feature.

> Tests will test:
> - board state - set board state
> - valid? - valid movements of pieces
> - en passant - test for en passant
> - castling - test that castling works correctly
> - in check?
> - checkmate?

4. Start properly bulking out tickets on trello board, class structure, testing
5. Discussed properly structuring repo, branches, classes e.t.c 
6. Discussed keeping more notes on project 
7. Come more prepared for next meeting; prep questions, whats my focus, whats blocking me, any clarification on anything and going in the right direction?

## SUPERVISOR MEETING 20/01/2022 @10-10:45am

### Action Points:

- Make small changes to poster
- Bullet point more, too wordy
- More related images
- Talk more about future application

### Notes from meeting: 
feels too wordy, 
1-2 secs of attention for brain to break it down
make more bullet points, bold more important sentences 
time complexity, deeply engaging and understanding them
computing principles and coding principles
legal move evaluation
Computer able to make random valid moves 
crux of this is trying to understand algorithmic complexity of a solution search algorithm
algorithms im studying could be used in other domains, where are we using computers to search for a solution
computers are really good at this form of branching and searching so this could be really useful in other domains
im involved in personal study and growth on this problem domain search and evaluating
same algorithms that solve many problems in other games and things
model climate change, whats the best move to make...
talk about complexity, legal move validation/search e.g. castling and en-passant

difficult questions?
this project is personal exploration, im going to find out...

c# can be compiled for various platforms get logo, language is good enough for objectives and goals of proejct

## SUPERVISOR MEETING 20/01/2022 @3-3:50pm

### Action Points:
- Agreed on project marking scheme
- Create project write up document, assign headings and start getting some research and literature reviews down of the domain and its problems from the agreed mark scheme.
- Split project up into 3 diff projects: Visual UI, Unit tests, and the actual chess engine itself

### Notes from meeting: 
Spoke about tactics to keeping work flow moving and balancing work load by switching between working on documentation and the actual solution itself. Not only will this help not miss anything but it will mean there is not a huge bulk of writing to do at the end of the project.
Spoke about this getting the ball rolling now so should be able to come to regular weeekly meetings with more direction and questions on particular coding problems and things rather than general, 'what do i do help me!'

## SUPERVISOR MEETNING 09/02/2022 @10-10:35

### Action Points
- Spoke more in depth about project report

### Notes from meeting:
Supervisor spoke and explained more in depth what each section of the report needed to display to the reader.

## SUPERVISOR MEETNING 24/02/2022 @10-10:45

### Action Points
- Reviewed report content, got some reccomendations on what to write about
- Spoke about setting up unit tests first to get started on code

### Notes from meeting:
3ghz processor, how many operations can this perform? Given this many positions how long will it take… ball park estimate, different search depth
Spoke about getting on with code, trying to do some testing, think about class structure
Write tests until your happy with how they look and how the code you write will function well. 

## SUPERVISOR MEETING 07/03/2022 @3-3:45pm

## Action Points
- Merge branches back to master and use better branch technique
- Focus on VisualBoardClickFeedback feature so users can interact with the GUI
- Next, ModifyBoardState method to represent these changes in the engines memory
- Look into some sort of new easier human readable board representation for use in testing
- Write about data structures used inside the document for the project

## Notes:
Adopt feature branch strategy, ticket no and keywords
Merge all branches so there is only one and branches for features
Focus on VisualBoardClickFeedback feature:
When click on a piece get some feedback for the user to see that something has happened, for example highlight valid squares to move to
Next, ModifyBoardState
ASCI board representation from board state to make tests more readable, diff way of representing boards from FEN
BoardtoFENstring update FEN in GUI when user makes move
Doc - talk about data structures

## SUPERVISOR MEETING 21/03/2022 @3-3:45pm

## Action Points
- Implement clickable GUI; approach with image box layers for different needs, and some kind of coordinate converter to get what piece was clicked
- Implement error catcher for gui in FEN string validation; try catch

## Notes:
FEN validation: regex checks? TRY CATCH good enough
Look into how to get clickable pieces on the gui, need some human interaction in the program. COORDINATES CONVERTER Return square on