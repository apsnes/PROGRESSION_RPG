using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Food : GameItem
    {
        public int Vitality { get; set; }

        public Food(int itemID, string name, int price, int itemLevel, int vitality) : base(itemID, name, price, itemLevel)
        {
            Vitality = vitality;
        }

        public new Food Clone()
        {
            return new Food(ItemID, Name, Price, ItemLevel, Vitality);
        }
    }
}
