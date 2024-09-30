using Client.Mobile.MauiApp.Models;

namespace Client.Mobile.MauiApp;

public partial class MainPage : ContentPage
{


    private GameBoard _gameBoard;
        
    public MainPage()
    {
        InitializeComponent();
        _gameBoard = new GameBoard();
        _gameBoard.InitializeBoard();
        DrawBoard();
    }

    private void DrawBoard()
    {
        BoardGrid.Children.Clear();
        for (int i = 0; i < _gameBoard.Rows; i++)
        {
            for (int j = 0; j < _gameBoard.Columns; j++)
            {
                var button = new Button
                {
                    Text = _gameBoard.Board[i, j] == 0 ? "" : _gameBoard.Board[i, j].ToString(),
                    BackgroundColor = _gameBoard.Revealed[i, j] ? Colors.LightGray : Colors.White
                };
                button.Clicked += (sender, args) => OnTokenClicked(i, j);
                BoardGrid.Children.Add(button, j, i);
            }
        }
    }
}