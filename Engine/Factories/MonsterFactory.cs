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
        public static Monsters CreateMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monsters evilBun = new Monsters("Evil Bunny", "evilbun.png", 1000, 1000, 1000, 2500, 10);
                    AddLootItem(evilBun, 1002, 100, 1);
                    return evilBun;
                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
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
