using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World newWorld = new World();
            newWorld.AddLocation(0, -1, "Home", "Sanctuary", "pack://application:,,,/Engine;component/Images/Locations/FirstHouse.png");
            newWorld.AddLocation(-1, -1, "Stone Forest", "Danger", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            newWorld.AddLocation(-1, -2, "Evil Bunny's Lair", "Highly Dangerous", "pack://application:,,,/Engine;component/Images/Locations/ComingSoon.png");
            return newWorld;
        }
    }
}
