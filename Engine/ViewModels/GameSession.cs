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
        public Location CurrentLocation { get; set; }

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

            CurrentLocation = new Location()
            {
                Name = "Home",
                XCoordinate = 0,
                YCoordinate = -1,
                Description = "Sanctuary",
                ImageName = "pack://application:,,,/Engine;component/Images/Locations/FirstHouse.png"
            };

        }
    }
}
