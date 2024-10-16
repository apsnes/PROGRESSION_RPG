using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _gameItems;

        static ItemFactory()
        {
            _gameItems =
            [
                new Weapon(1001, "Wooden Staff", 1000, 1, 10, 2),
                new Weapon(1002, "Evil Bunny's Scepter", 10000, 10, 95, 35),
                new Weapon(1003, "Demonic Glowstorm Stave of Purgatory", 1000000, 50, 500, 250),
                new Weapon(1004, "Heavy Blacksmith's Rod", 10000, 15, 140, 35),
                new Weapon(1005, "Undead Bonestaff", 10000, 15, 105, 70),
                new Weapon(1006, "Townspeople's Hope", 25000, 20, 200, 90),
            ];
        }

        public static GameItem CreateGameItem(int itemID)
        {
            GameItem item = _gameItems.FirstOrDefault(item => item.ItemID == itemID);
            if (item != null)
            {
                return item.Clone();
            }
            return null;
        }
    }
}
