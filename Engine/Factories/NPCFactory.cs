using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class NPCFactory
    {
        private static readonly List<NPC> _npcs = new();

        static NPCFactory()
        {
            NPC mango = new NPC("Mango");
            mango.AddItemToInventory(ItemFactory.CreateGameItem(1006));
            mango.AddItemToInventory(ItemFactory.CreateGameItem(1004));
            mango.AddItemToInventory(ItemFactory.CreateGameItem(3001));
            mango.AddItemToInventory(ItemFactory.CreateGameItem(3001));
            mango.AddItemToInventory(ItemFactory.CreateGameItem(3001));
            mango.AddItemToInventory(ItemFactory.CreateGameItem(2003));
            mango.AddItemToInventory(ItemFactory.CreateGameItem(2004));

            NPC localTrader = new NPC("Local Trader");
            localTrader.AddItemToInventory(ItemFactory.CreateGameItem(1007));
            localTrader.AddItemToInventory(ItemFactory.CreateGameItem(3001));
            localTrader.AddItemToInventory(ItemFactory.CreateGameItem(3001));
            localTrader.AddItemToInventory(ItemFactory.CreateGameItem(3001));

            AddNPCToList(mango);
            AddNPCToList(localTrader);
        }

        public static NPC GetNPCByName(string name)
        {
            return _npcs.FirstOrDefault(t => t.Name == name);
        }

        public static void AddNPCToList(NPC npc)
        {
            if (_npcs.Any(t => t.Name == npc.Name))
            {
                throw new ArgumentException($"There is already an NPC named {npc.Name}");
            }
            _npcs.Add(npc);
        }
    }
}
