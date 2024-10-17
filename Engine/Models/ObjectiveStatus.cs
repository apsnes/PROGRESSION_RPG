using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class ObjectiveStatus
    {
        public Objective PlayerObjective { get; set; }
        public bool IsCompleted { get; set; }

        public ObjectiveStatus(Objective objective)
        {
            PlayerObjective = objective;
            IsCompleted = false;
        }
    }
}
