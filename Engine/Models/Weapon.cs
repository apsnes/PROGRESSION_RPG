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
        public string ImageName { get; set; }

        public Weapon(int itemID, string name, string imageName, int price, int itemLevel, int power, int defence) : base(itemID, name, price, itemLevel)
        {
            Power = power;
            Defence = defence;
            ImageName = imageName;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemID, Name, ImageName, Price, ItemLevel, Power, Defence);
        }
    }
}
