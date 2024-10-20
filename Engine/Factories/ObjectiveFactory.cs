﻿using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    internal static class ObjectiveFactory
    {
        private static readonly List<Objective> _objectives = new List<Objective>();

        static ObjectiveFactory()
        {
            List<ItemQuantity> requiredItems = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            //requiredItems.Add(new ItemQuantity(2001, 5));
            //rewardItems.Add(new ItemQuantity(3001, 2));
            requiredItems.Add(new ItemQuantity(2002, 5));
            rewardItems.Add(new ItemQuantity(3001, 2));

            //_objectives.Add(new Objective(1, "Mushroom Collector", "Collect some yummy wild mushrooms from the forest for the villager", requiredItems, 50, 500, rewardItems));
            _objectives.Add(new Objective(2, "Demon Slayer", "An old grey bunny approaches you. It's a local shopkeeper. They explain that there's recently been an increase in Demon Imps stealing her fresh fruit. They ask for help in clearing out the parasites from the area. Slay 5 Demon Imps and bring their skeletons as proof.", requiredItems, 50, 500, rewardItems));
        }

        internal static Objective GetObjective(int id)
        {
            return _objectives.FirstOrDefault(objective => objective.ID == id);
        }

    }
}
