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
                    Monsters evilBun = new Monsters("Evil Bunny", "evilbun.png", 300, 300, 1000, 2500, 10);
                    AddLootItem(evilBun, 1002, 100, 1);
                    return evilBun;
                case 2:
                    Monsters demonBun = new Monsters("Demonic Bunny of Purgatory", "demonBunny.png", 10000, 10000, 10000, 50000, 100);
                    AddLootItem(demonBun, 1003, 100, 1);
                    return demonBun;
                case 3:
                    Monsters fireyImp = new Monsters("Firey Imp", "fireyImp.png", 150, 150, 100, 200, 4);
                    AddLootItem(fireyImp, 2002, 80, 3);
                    return fireyImp;
                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }
        public static void AddLootItem(Monsters monster, int itemID, int percentage, int maxCount)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                maxCount = RandomNumberGenerator.NumberBetween(1, maxCount);
                for (int i = 0; i < maxCount; i++)
                {
                    monster.Inventory.Add(new ItemQuantity(itemID, 1));
                }
            }
        }
    }
}
