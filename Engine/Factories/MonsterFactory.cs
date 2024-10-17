using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        private static List<Monsters> _monsters;

        static MonsterFactory()
        {
            _monsters =
            [
                new Monsters(1, "Evil Bunny", "evilbun.png", 1000, 1000, 1000, 2500, 10),
            ];
        }

        public static Monsters CreateMonster(int monsterID)
        {
            Monsters monster = _monsters.FirstOrDefault(monster => monster.MonsterID == monsterID);
            if (monster != null)
            {
                return monster.Clone();
            }
            return null;
        }

        public static void AddLootItem(Monsters monster, int itemID, int percentage, int maxCount)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                maxCount = RandomNumberGenerator.NumberBetween(1, maxCount + 1);
                monster.Inventory.Add(new ItemQuantity(itemID, maxCount));
            }
        }
    }
}
