# Use Case: Tic-Tac-Toe

## Overview
**Game**: Tic-Tac-Toe  
**Players**: 2  
**Board Size**: 3x3 grid  
**Objective**: Place three of your symbols (X or O) in a row to win.

## Use Case

### Title: Play a Game of Tic-Tac-Toe

**Primary Actors**: Player 1 (X), Player 2 (O)  
**Goal**: To complete a sequence of three of the same symbols in a horizontal, vertical, or diagonal line.

### Preconditions
- A 3x3 grid is available and empty.
- Both players understand the rules of Tic-Tac-Toe.

### Trigger
- Player 1 starts the game by placing their symbol (X) in any empty cell of the board.

### Main Success Scenario
1. **Player 1** places an X in an empty cell of the 3x3 grid.
2. **Player 2** places an O in an empty cell.
3. Players alternate turns, each marking an empty cell with their symbol (X or O).
4. A player wins if they succeed in placing three of their symbols in a row (horizontally, vertically, or diagonally).
5. If all cells are filled without either player achieving three in a row, the game ends in a draw.

### Postconditions
- The game ends either with a win (one player gets three in a row) or a draw (all cells are filled).

### Alternative Flows
- If a player places their symbol incorrectly (e.g., in an already occupied cell), they must retry until they choose a valid move.
