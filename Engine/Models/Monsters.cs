using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Monsters : BaseClass
    {
        private int _hp;
        private int _hpPercentage;
        public string ImageName { get; set; }
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int HP
        {
            get { return _hp; }
            private set
            {
                _hp = value;
                OnPropertyChanged(nameof(HP));
            }
        }
        public int HPPercentage
        {
            get { return _hpPercentage;  }
            private set
            {
                _hpPercentage = value;
                OnPropertyChanged(nameof(HPPercentage));
            }
        }
        public int RewardEXP { get; set; }
        public int RewardGold { get; set; }
        public int DamagePower { get; set; }
        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monsters(string name, string imageName, int maxHp, int hp, int rewardEXP, int rewardGold, int dmg)
        {
            Name = name; ImageName = string.Format("pack://application:,,,/Engine;component/Images/Monsters/{0}", imageName); MaxHP = maxHp; HP = hp; HPPercentage = hp / maxHp * 100; RewardEXP = rewardEXP; RewardGold = rewardGold; DamagePower = dmg; Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
