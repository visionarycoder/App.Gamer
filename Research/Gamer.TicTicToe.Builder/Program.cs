using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace Gamer.TicTicToe.Builder;

internal class Program
{
  static void Main(string[] args)
  {



  }
}

public interface IRule
{
  bool IsPlayable(GamePlayableEngine.IBoard board);
}

public class GamePlayableEngine
{

  private HashSet<IRule> gameRules;

  public GamePlayableEngine(params IRule[] gameRules)
  {
    this.gameRules = new HashSet<IRule>(gameRules);
  }

  public bool IsPlayable(IBoard board)
  {
    var isPlayable = gameRules.All(i => i.IsPlayable(board));
    return isPlayable;
  }
}

public class Address
{
  public int X { get; set; }
  public int Y { get; set; }
}

public class Board : NMKGame
{

}

public class NMKGame
{
  public int N { get; }
  public int M { get; }
  public int K { get; }

  public NMKGame(int n, int m, int k)
  {
    N = n;
    M = m;
    K = k;
  }

}

public class NMKGameRule
{
  public bool IsPlayable(NMKGame game)
  {

    return game.N > 0 && game.M > 0 && game.K > 0;
  }
}


