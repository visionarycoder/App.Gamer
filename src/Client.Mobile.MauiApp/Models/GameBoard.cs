namespace Client.Mobile.MauiApp.Models;

public class GameBoard
{
    public int Rows { get; set; } = 9;
    public int Columns { get; set; } = 9;
    public int[,] Board { get; set; }
    public bool[,] Revealed { get; set; }

    public GameBoard()
    {
        Board = new int[Rows, Columns];
        Revealed = new bool[Rows, Columns];
    }

    public void InitializeBoard()
    {
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Board[i, j] = random.Next(1, 10);
            }
        }
    }

    public bool SelectTokens(int row1, int col1, int row2, int col2)
    {
        if (Board[row1, col1] == Board[row2, col2] || Board[row1, col1] + Board[row2, col2] == 10)
        {
            Board[row1, col1] = 0;
            Board[row2, col2] = 0;
            return true;
        }
        return false;
    }

    public void AddNewTurn()
    {
        List<int> existingTokens = new List<int>();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Board[i, j] != 0)
                {
                    existingTokens.Add(Board[i, j]);
                }
            }
        }

        Random random = new Random();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Board[i, j] == 0 && existingTokens.Count > 0)
                {
                    int index = random.Next(existingTokens.Count);
                    Board[i, j] = existingTokens[index];
                    existingTokens.RemoveAt(index);
                }
            }
        }
    }
        
}