using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int Power { get; set; }
        public int Defence { get; set; }

        public Weapon(int itemID, string name, int price, int itemLevel, int power, int defence) : base(itemID, name, price, itemLevel)
        {
            Power = power;
            Defence = defence;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemID, Name, Price, ItemLevel, Power, Defence);
        }



    }
}
