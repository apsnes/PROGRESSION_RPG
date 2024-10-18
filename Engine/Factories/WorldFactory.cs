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
            newWorld.AddLocation(0, 0, "Home", "Sanctuary", "FirstHouse.png");

            newWorld.AddLocation(0, -1, "Stone Forest", "Danger", "stoneForest.png");
            newWorld.LocationAt(0, -1).AddMonster(3, 6);

            newWorld.AddLocation(0, -2, "Evil Bunny's Lair", "Highly Dangerous", "ComingSoon.png");
            newWorld.LocationAt(0, -2).AddMonster(1, 100);

            newWorld.AddLocation(1, -2, "Tranquil Respite", "Sanctuary", "ComingSoon.png");

            newWorld.AddLocation(2, -2, "TBD Road", "Danger", "ComingSoon.png");
            newWorld.LocationAt(2, -2).AddMonster(3, 6);

            newWorld.AddLocation(3, -2, "Rabbit Hop Trail", "Danger", "rabbithoptrail.png");
            newWorld.LocationAt(3, -2).AddMonster(3, 6);

            newWorld.AddLocation(3, -1, "Rabbit Hop Town", "Sanctuary", "ComingSoon.png");
            //newWorld.LocationAt(3, -1).ObecjtivesHere.Add(ObjectiveFactory.GetObjective(1));
            newWorld.LocationAt(3, -1).ObecjtivesHere.Add(ObjectiveFactory.GetObjective(2));

            newWorld.AddLocation(2, -1, "Rabbit Hop Town Markets", "Sanctuary", "rabbitHopMarkets.png");
            newWorld.LocationAt(2, -1).NPCHere = NPCFactory.GetNPCByName("Mango");

            newWorld.AddLocation(4, -1, "TBD Town", "Sanctuary", "ComingSoon.png");

            newWorld.AddLocation(3, 0, "TBD", "Danger", "ComingSoon.png");
            newWorld.LocationAt(3, 0).AddMonster(3, 6);

            newWorld.AddLocation(3, 1, "Hellish Cavern", "Extremely Dangerous", "ComingSoon.png");
            newWorld.LocationAt(3, 1).AddMonster(2, 100);

            newWorld.AddLocation(-1, 0, "Yard", "Sanctuary", "yard.png");

            newWorld.AddLocation(0, 1, "Local Trader", "Sanctuary", "localtrader.png");
            newWorld.LocationAt(0, 1).NPCHere = NPCFactory.GetNPCByName("Local Trader");

            return newWorld;
        }
    }
}
