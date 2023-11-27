namespace Gamer.Resources.Data.GamerDb.Models;

	
	public class GameDefinition
	{

		private static int id;
		public int Id { get; init; } = id++;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string GameType { get; set; } = string.Empty;
		public int MaxNumberOfPlayers { get; set; }
		public int MinNumberOfPlayers { get; set; }

		public virtual ICollection<GameSession> GameSessions { get; } = new List<GameSession>();

	}