using Gamer.Components.Accessors.Models;
using Gamer.Framework.Enums;
using Gamer.Resources.Data.GamerDb.Models;

namespace Gamer.Components.Accessors.Extensions;

public static class PlayerExtension
{

	public static Player Convert(this GamePlayer source)
	{

		ArgumentNullException.ThrowIfNull(source, nameof(source));
		var playerType = source.PlayerType switch
		{
			"Human" => PlayerType.Human,
			"Computer" => PlayerType.Computer,
			_ => PlayerType.Unknown
		};

		var target = new Player
		{
			Id = source.Id,
			Name = source.Name,
			PlayerType = playerType,
		};
		return target;

	}

}