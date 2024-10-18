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
            _gameItems.Add(new Weapon(1001, "Wooden Staff", "pack://application:,,,/Engine;component/Images/Weapons/woodenStaff.png", 1000, 1, 10, 2));
            _gameItems.Add(new Weapon(1002, "Evil Bunny's Scepter", "pack://application:,,,/Engine;component/Images/Weapons/tempWeapon.png", 10000, 10, 95, 35));
            _gameItems.Add(new Weapon(1003, "Demonic Glowstorm Stave of Purgatory", "pack://application:,,,/Engine;component/Images/Weapons/tempWeapon.png", 1000000, 50, 500, 250));
            _gameItems.Add(new Weapon(1004, "Heavy Blacksmith's Rod", "pack://application:,,,/Engine;component/Images/Weapons/tempWeapon.png", 10000, 15, 140, 35));
            _gameItems.Add(new Weapon(1005, "Undead Bonestaff", "pack://application:,,,/Engine;component/Images/Weapons/tempWeapon.png", 10000, 20, 105, 70));
            _gameItems.Add(new Weapon(1006, "Townspeople's Hope", "pack://application:,,,/Engine;component/Images/Weapons/tempWeapon.png", 25000, 25, 200, 90));
            _gameItems.Add(new Weapon(1007, "Arcane OakStaff", "pack://application:,,,/Engine;component/Images/Weapons/tempWeapon.png", 6000, 15, 20, 4));

            _gameItems.Add(new Food(3001, "Mushroom Soup", 250, 1, 15));

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
                else if (item is Food)
                {
                    return (item as Food).Clone();
                }
                return item.Clone();
            }
            return null;
        }
    }
}
