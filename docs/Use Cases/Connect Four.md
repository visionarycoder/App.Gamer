# Use Case: Connect Four (Mini Version)

## Overview
**Game**: Connect Four (Mini Version)  
**Players**: 2  
**Board Size**: 4x4 grid  
**Objective**: Drop colored discs into the grid and align four in a row to win.

## Use Case

### Title: Play a Game of Mini Connect Four

**Primary Actors**: Player 1 (Red), Player 2 (Yellow)  
**Goal**: To complete a sequence of four discs of the same color in a row, either horizontally, vertically, or diagonally.

### Preconditions
- A 4x4 grid is available and empty.
- Both players understand the rules of Connect Four.

### Trigger
- Player 1 starts the game by dropping their disc (Red) into any column of the grid.

### Main Success Scenario
1. **Player 1** drops a red disc into one of the columns of the 4x4 grid.
2. **Player 2** drops a yellow disc into one of the columns.
3. Players take turns dropping their discs into the columns, with the discs falling to the lowest available space in the selected column.
4. A player wins if they achieve four discs in a row (horizontally, vertically, or diagonally).
5. If all columns are filled without either player achieving four in a row, the game ends in a draw.

### Postconditions
- The game ends either with a win (one player gets four in a row) or a draw (all columns are filled).

### Alternative Flows
- If a player attempts to drop a disc into a full column, they must choose another column until they find an available space.

