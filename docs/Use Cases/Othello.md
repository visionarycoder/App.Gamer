
# Use Case: Othello (Reversi)

## Overview
**Game**: Othello (Reversi)  
**Players**: 2  
**Board Size**: 8x8 grid  
**Objective**: Capture as many opponent discs as possible by surrounding them with your own discs.

## Use Case

### Title: Play a Game of Othello

**Primary Actors**: Player 1 (Black), Player 2 (White)  
**Goal**: To have the majority of discs on the board by the end of the game by capturing opponent discs.

### Preconditions
- An 8x8 grid is available and empty except for the initial four discs (two black and two white) in the center.
- Both players understand the rules of Othello.

### Trigger
- Player 1 (Black) starts the game by placing a black disc to capture at least one of Player 2's discs.

### Main Success Scenario
1. **Player 1** places a black disc on the board, capturing at least one white disc by surrounding it between two black discs.
2. **Player 2** places a white disc on the board, capturing at least one black disc by surrounding it between two white discs.
3. Players alternate turns, each placing their disc to capture as many opponent discs as possible.
4. The game ends when neither player can make a valid move, or the board is completely filled.
5. The player with the majority of discs in their color on the board wins.

### Postconditions
- The game ends either with a win (one player has more discs on the board) or a draw (both players have the same number of discs).

### Alternative Flows
- If a player cannot make a valid move, they must pass their turn to the opponent.

