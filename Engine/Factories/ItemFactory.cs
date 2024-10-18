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
        private static readonly List<GameItem> _gameItems = new();

        static ItemFactory()
        {
            _gameItems.Add(new Weapon(1001, "Wooden Staff", 1000, 1, 10, 2));
            _gameItems.Add(new Weapon(1002, "Evil Bunny's Scepter", 10000, 10, 95, 35));
            _gameItems.Add(new Weapon(1003, "Demonic Glowstorm Stave of Purgatory", 1000000, 50, 500, 250));
            _gameItems.Add(new Weapon(1004, "Heavy Blacksmith's Rod", 10000, 15, 140, 35));
            _gameItems.Add(new Weapon(1005, "Undead Bonestaff", 10000, 15, 105, 70));
            _gameItems.Add(new Weapon(1006, "Townspeople's Hope", 25000, 20, 200, 90));

            _gameItems.Add(new Food(2001, "Mushroom Soup", 250, 1, 15));

            _gameItems.Add(new GameItem(2001, "Wild Mushroom", 50, 1));
            _gameItems.Add(new GameItem(2002, "Imp Skeleton", 110, 1));
            _gameItems.Add(new GameItem(2003, "Wildflower Rose", 100, 1));
            _gameItems.Add(new GameItem(2004, "Sunflower Daisy", 100, 1));
        }

        public static GameItem CreateGameItem(int itemID)
        {
            GameItem item = _gameItems.FirstOrDefault(item => item.ItemID == itemID);
            if (item != null)
            {
                if (item is Weapon)
                {
                    return (item as Weapon).Clone();
                }
                return item.Clone();
            }
            return null;
        }
    }
}
