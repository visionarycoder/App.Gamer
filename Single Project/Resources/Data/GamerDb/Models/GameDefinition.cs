namespace Gamer.Resources.Data.GamerDb.Models;

	
	public class GameDefinition
	{

		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int GameTypeId { get; set; }

	}

