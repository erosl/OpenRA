#region Copyright & License Information
/*
 * Copyright (c) The OpenRA Developers and Contributors
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using System.Linq;
using NUnit.Framework;

namespace OpenRA.Test
{
	[TestFixture]
	sealed class MapPlayersTest
	{
		[Test]
		public void ToMiniYamlSortsMultiplayerPlayers()
		{
			var players = new MapPlayers();
			players.Players.Add("Neutral", new PlayerReference { Name = "Neutral" });
			players.Players.Add("Multi1", new PlayerReference { Name = "Multi1" });
			players.Players.Add("Multi0", new PlayerReference { Name = "Multi0" });

			var definitions = players.ToMiniYaml().Select(n => n.Key);
			Assert.That(definitions, Is.EqualTo(new[]
			{
				"PlayerReference@Neutral",
				"PlayerReference@Multi0",
				"PlayerReference@Multi1"
			}));
		}
	}
}
