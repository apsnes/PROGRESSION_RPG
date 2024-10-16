using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Objective
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ItemQuantity> RequiredItems { get; set; }
        public int RewardEXP { get; set; }
        public int RewardGold { get; set; }
        public List<ItemQuantity> RewardItems { get; set; }

        public Objective(int iD, string name, string description, List<ItemQuantity> requiredItems, int rewardEXP, int rewardGold, List<ItemQuantity> rewardItems)
        {
            ID = iD;
            Name = name;
            Description = description;
            RequiredItems = requiredItems;
            RewardEXP = rewardEXP;
            RewardGold = rewardGold;
            RewardItems = rewardItems;
        }
    }
}
