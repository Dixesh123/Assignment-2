**Overview**
-In the straightforward two-player console game Gem Hunters, players navigate a 6x6 grid to gather gems while dodging obstacles. The game is won by the player who has the most jewels after 30 turns.

*How to Begin the Game:

1.Launch the software : Player 1 (P1) begins the game in the top-left corner   (0,0), while Player 2 (P2) begins in the bottom-right corner (5,5).
Loop of the Game:

2.Each player travels around the board in turn : Players can move left (L), right (R), down (D), and up (U) by inputting the matching character.
-Moves are validated by the game to make sure they stay inside the lines and don't enter any obstacle cells.

3.Gather Jewels:
-By going into cells that have a G on them, players can get gems:
 The player's gem total rises by one with each gem they acquire.
 Final Score:

4.Thirty turns is when the game concludes:
-The winner is the player who has amassed the most jewels.
-If the quantity of is the same for both players.

*Code Organization:
The game is divided up into multiple classes:

1.Class of Position:
-Carries the player's position on the board's coordinates (X, Y).

2.Class of Player:
-Possesses attributes for name, position, and number of gems, representing a player.
 includes a way to direct the player's movement in a predetermined direction.
 
3.Class of Cell:
-Represents a cell on the board that has an object inside of it, such as a gem, player, obstacle, or empty space.

4.Board Meeting:
-Controls a 6x6 cell grid.
-Puts obstacles, jewels, and players on the board.
-Shows the board's current condition.
-Verifies player movements and manages the gathering of gems.

5.Class of Game:
-Oversees player turns and the game loop, as well as the overall game flow.
-Alternates the players' turns.
-Determines if the 30-turn game is over.
-At the conclusion of the game, declares the winner.

6.Course Class:
-Includes the Main method, which serves as the application's entry point.
-Launches and initializes the game.

*Flow of the Game:
1.Set Up the Board and Players:
-The beginning positions, gem and obstacle placements, and board are initialized for both players and the board.

2.Player Motions:
-The move direction is entered by the player upon prompting.
-The motion is approved by the board.
-The player moves if the move is valid, and any gems at the new location are collected.

3.Activate the switch:
-The other player takes the turn at this point.

4.Final Stage:
-The game is over after 30 turns.
-The number of gems determines the winner.

*To sum up:
-A platform for studying fundamental C# game development principles, Gem Hunters is an easy-to-learn arcade game. Further improvements and learning opportunities can be well-founded in the code structure and flow.
