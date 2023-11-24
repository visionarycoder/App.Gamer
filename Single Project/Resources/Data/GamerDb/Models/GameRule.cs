using RulesEngine.Models;

namespace Gamer.Resources.Data.GamerDb.Models;

public class GameRule
{
	
	public int Id { get; set; }
	public Rule Rule { get; set; } = null!;

}

public class GameWorkflow
{
	
	public int Id { get; set; }
	public Workflow Workflow { get; set; } = null!;

}