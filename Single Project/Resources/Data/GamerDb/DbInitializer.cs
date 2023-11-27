using Gamer.Resources.Data.GamerDb.Models;

namespace Gamer.Resources.Data.GamerDb
{

	internal class DbInitializer
	{

		public static void Initialize(GamerContext ctx)
		{

			ArgumentNullException.ThrowIfNull(ctx, nameof(ctx));

			ctx.Database.EnsureCreated();
			if(ctx.GameDefinitions.Any())
				return;

			var gameDefinitions = new[]
			{
				new GameDefinition {Name = "Tic Tac Toe", Description = "Tic Tac Toe", GameType = "TicTacToe", MaxNumberOfPlayers = 2, MinNumberOfPlayers = 0 },
				new GameDefinition {Name = "Connect Four", Description = "Connect Four", GameType = "ConnectFour"},
				new GameDefinition {Name = "Checkers", Description = "Checkers", GameType = "Checkers"},
				new GameDefinition {Name = "Chess", Description = "Chess", GameType = "Chess"},
				new GameDefinition {Name = "Go", Description = "Go", GameType = "Go"},
				new GameDefinition {Name = "Othello", Description = "Othello", GameType = "Othello"},
				new GameDefinition {Name = "Backgammon", Description = "Backgammon", GameType = "Backgammon"},
				new GameDefinition {Name = "Mancala", Description = "Mancala", GameType = "Mancala"},
				new GameDefinition {Name = "Poker", Description = "Poker", GameType = "Poker"},
				new GameDefinition {Name = "Blackjack", Description = "Blackjack", GameType = "Blackjack"},
				new GameDefinition {Name = "Texas Hold'em", Description = "Texas Hold'em", GameType = "TexasHoldem"},
				new GameDefinition {Name = "Hearts", Description = "Hearts", GameType = "Hearts"},
				new GameDefinition {Name = "Spades", Description = "Spades", GameType = "Spades"},
				new GameDefinition {Name = "Bridge", Description = "Bridge", GameType = "Bridge"},
				new GameDefinition {Name = "Gin Rummy", Description = "Gin Rummy", GameType = "GinRummy"},
				new GameDefinition {Name = "Cribbage", Description = "Cribbage", GameType = "Cribbage"},
				new GameDefinition {Name = "Euchre", Description = "Euchre", GameType = "Euchre"},
				new GameDefinition {Name = "Pinochle", Description = "Pinochle", GameType = "Pinochle"},
				new GameDefinition {Name = "Mahjong", Description = "Mahjong",}
			};
			ctx.GameDefinitions.AddRange(gameDefinitions);
			ctx.SaveChanges();


		}

	}
}
