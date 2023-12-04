using System.Text;
using Gamer.Components.Shared.Models;

namespace Gamer.Clients.Content.Helpers;


internal static class ConsoleHelper
{

    public static string PrintBoard(List<string> tokens)
    {
        var board = new StringBuilder();
        board.AppendLine($"\t {tokens[0]} | {tokens[1]} | {tokens[2]} ");
        board.AppendLine($"\t---|---|---");
        board.AppendLine($"\t {tokens[3]} | {tokens[4]} | {tokens[5]} ");
        board.AppendLine($"\t---|---|---");
        board.AppendLine($"\t {tokens[6]} | {tokens[7]} | {tokens[8]} ");
        return board.ToString();
    }

    public static string PrintTurnPrompt(GamePlayer gamePlayer, GameDefinition gameDefinition)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{gamePlayer.Name}: {gameDefinition.TurnPrompt}");
        return builder.ToString();
    }

    public static string PrintWinner(GamePlayer gamePlayer)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{gamePlayer.Name} wins!");
        return builder.ToString();
    }

    public static string PrintDraw()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Draw!");
        return builder.ToString();
    }

}