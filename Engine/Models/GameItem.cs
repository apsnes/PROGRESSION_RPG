using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ItemLevel { get; set; }

        public GameItem(int itemID, string name, int price, int itemLevel)
        {
            ItemID = itemID;
            Name = name;
            Price = price;
            ItemLevel = itemLevel;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemID, Name, Price, ItemLevel);
        }
    }
}
