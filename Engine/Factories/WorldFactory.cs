using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();
            newWorld.AddLocation(0, 0, "Home", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/FirstHouse.png");

            newWorld.AddLocation(0, -1, "Stone Forest", "Danger", "pack://application:,,,/Engine;component/Images/Locations/stoneForest.png");
            newWorld.LocationAt(0, -1).AddMonster(3, 6);

            newWorld.AddLocation(0, -2, "Evil Bunny's Lair", "Highly Dangerous", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            newWorld.LocationAt(0, -2).AddMonster(1, 100);

            newWorld.AddLocation(1, -2, "Tranquil Respite", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(2, -2, "TBD Road", "Danger", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            newWorld.LocationAt(2, -2).AddMonster(3, 6);

            newWorld.AddLocation(3, -2, "Rabbit Hop Trail", "Danger", "pack://application:,,,/Engine;component/Images/Locations/rabbithoptrail.png");
            newWorld.LocationAt(3, -2).AddMonster(3, 6);

            newWorld.AddLocation(3, -1, "Rabbit Hop Town", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            newWorld.LocationAt(3, -1).ObecjtivesHere.Add(ObjectiveFactory.GetObjective(1));

            newWorld.AddLocation(2, -1, "Rabbit Hop Town Markets", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/rabbitHopMarkets.png");

            newWorld.AddLocation(4, -1, "TBD Town", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(3, 0, "TBD", "Danger", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            newWorld.LocationAt(3, 0).AddMonster(3, 6);

            newWorld.AddLocation(3, 1, "Hellish Cavern", "Extremely Dangerous", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            newWorld.LocationAt(3, 1).AddMonster(2, 100);

            newWorld.AddLocation(-1, 0, "Yard", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/yard.png");

            newWorld.AddLocation(0, 1, "Local Trader", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/localtrader.png");

            return newWorld;
        }
    }
}
