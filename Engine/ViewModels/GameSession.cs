using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class GameSession

    {
        public Player CurrentPlayer { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player()
            {
                Name = "Player One",
                Gold = 5000,
                EXP = 0,
                Level = 1,
                HP = 100,
                Job = "Mage"
            };
        }
    }
}
