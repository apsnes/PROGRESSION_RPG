using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<Objective> ObecjtivesHere { get; set; } = new List<Objective>();
        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        public void AddMonster(int monsterID, int chance)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                MonstersHere.First(m => m.MonsterID == monsterID).SpawnChance = chance;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterID, chance));
            }
        }
        public Monsters GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }
            int totalChance = MonstersHere.Sum(m => m.SpawnChance);
            int random = RandomNumberGenerator.NumberBetween(1, totalChance);
            int total = 0;
            foreach (MonsterEncounter monster in MonstersHere)
            {
                total += monster.SpawnChance;
                if (random <= total)
                {
                    return MonsterFactory.CreateMonster(monster.MonsterID);
                }
            }
            return MonsterFactory.CreateMonster(MonstersHere.Last().MonsterID);
        }
    }
}
