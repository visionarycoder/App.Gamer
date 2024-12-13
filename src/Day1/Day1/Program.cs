var board = new[,]
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

var currentPlayer = 'X';
var moves = 0;
var gameRunning = true;

while (gameRunning && moves < 9)
{

    Console.Clear();
    DrawBoard();
    Console.WriteLine($"Player {currentPlayer}, enter your move (1-9): ");
    var input = Console.ReadLine() ?? string.Empty;

    if (int.TryParse(input, out var position) && (position is >= 1 and <= 9) && MakeMove(position))
    {
        moves++;
        if (CheckForWin())
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine($"Player {currentPlayer} wins!");
            gameRunning = false;
        }
        else
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
    else
    {
        Console.WriteLine("Invalid move. Press any key to try again.");
        Console.ReadKey();
    }

}

if (moves == 9 && gameRunning)
{
    Console.Clear();
    DrawBoard();
    Console.WriteLine("It's a draw!");
}

return;

void DrawBoard()
{
    Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
}

bool MakeMove(int choice)
{

    var row = (choice - 1) / 3;
    var col = (choice - 1) % 3;

    if (board[row, col] == 'X' || board[row, col] == 'O')
        return false;

    board[row, col] = currentPlayer;
    return true;

}

bool CheckForWin()
{

    // Check rows
    if (board[0, 0] == currentPlayer && board[0, 1] == currentPlayer && board[0, 2] == currentPlayer)
    {
        return true;
    }

    if (board[1, 0] == currentPlayer && board[1, 1] == currentPlayer && board[1, 2] == currentPlayer)
    {
        return true;
    }

    if (board[2, 0] == currentPlayer && board[2, 1] == currentPlayer && board[2, 2] == currentPlayer)
    {
        return true;
    }

    // Check columns
    if (board[0, 0] == currentPlayer && board[1, 0] == currentPlayer && board[2, 0] == currentPlayer)
    {
        return true;
    }

    if (board[0, 1] == currentPlayer && board[1, 1] == currentPlayer && board[2, 1] == currentPlayer)
    {
        return true;
    }

    if (board[0, 2] == currentPlayer && board[1, 2] == currentPlayer && board[2, 2] == currentPlayer)
    {
        return true;
    }

    // Check diagonals
    if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
    {
        return true;
    }

    if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
    {
        return true;
    }

    // No winner yet 
    return false;

}
