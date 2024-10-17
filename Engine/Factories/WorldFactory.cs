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

            newWorld.AddLocation(0, -1, "Stone Forest", "Danger", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(0, -2, "Evil Bunny's Lair", "Highly Dangerous", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(1, -2, "Tranquil Respite", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(2, -2, "TBD Road", "Danger", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(3, -2, "TBD Road", "Danger", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(3, -1, "TBD Town", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            newWorld.LocationAt(3, -1).ObecjtivesHere.Add(ObjectiveFactory.GetObjective(1));

            newWorld.AddLocation(2, -1, "TBD Town Markets", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(4, -1, "TBD Town", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(3, 0, "TBD", "Danger", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(3, 1, "Boss", "Extremely Dangerous", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(-1, 0, "Yard", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            newWorld.AddLocation(0, 1, "Local Trader", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");

            return newWorld;
        }
    }
}
