# Ceng-Checkers
The aim of the project is to develop a two-player 
checkers-like board game called Ceng Checkers. 

General Information

The game is played on a 8*8 board. Players of the game are human (x) and computer (o). Human player starts the game. The game is turn based. The goal of the game is to be the first player to move all 9 pieces across the board and into their own home area. Each player's home area is the opposing 3*3 area. 

Initial Board

At the beginning of the game, each player has 9 pieces (as 3*3). Human player has x pieces in the bottom right 3*3 area of the board and computer player has o pieces in the top left 3*3 area. Each player wants to move his/her pieces to their home (opposite side of the board (3*3 area)).  

Game Playing Rules

All the moves are in 4 directions, diagonal moves cannot be used.

There are 2 move types for a player in each turn: Either a step or jump(s).

•	Step: If adjacent square of a piece in any direction (left, right, up or down) is empty, that piece can step into the empty square.
•	Jump: A piece can jump over only a single adjacent piece (his/her or opponent's). Jumping over 2 or more pieces or distant pieces is not allowed. 

Jumping operations can be continued with successive jumps (called jump chain) if possible, in the same turn. On the contrary, step operation is a single one. There is no capturing in this game, so all pieces remain active during the game. 

For each step or jump operation; human user firstly chooses the piece to move, then chooses the target square of the piece. 
1. Move cursor to the location of the piece
2. Choose the piece by pressing key Z
3. Move cursor to the target location 
4. Choose target square by pressing key X
    After the move;
5. If there is no successive jumps, end the move by pressing key C
6. If the player wants to jump again, go to stage 3  
