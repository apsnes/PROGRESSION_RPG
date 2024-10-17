using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class MonsterEncounter
    {
        public int MonsterID { get; set; }
        public int SpawnChance { get; set; }

        public MonsterEncounter(int id, int chance)
        {
            MonsterID = id;
            SpawnChance = chance;
        }
    }
}
