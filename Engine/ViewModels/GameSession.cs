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
        Player CurrentPlayer { get; set; }

        public GameSession()
        {
            CurrentPlayer = new();
            CurrentPlayer.Name = "Player One";
            CurrentPlayer.Gold = 5000;
            CurrentPlayer.EXP = 0;
            CurrentPlayer.Level = 1;
            CurrentPlayer.HP = 100;
            CurrentPlayer.Job = "Mage";
        }
    }
}
