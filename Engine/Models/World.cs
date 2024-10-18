using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        internal void AddLocation(int x, int y, string name, string desc, string imageName)
        {
            Location newLocation = new Location();
            newLocation.Name = name;
            newLocation.Description = desc;
            newLocation.ImageName = $"pack://application:,,,/Engine;component/Images/Locations/{imageName}";
            newLocation.XCoordinate = x;
            newLocation.YCoordinate = y;
            _locations.Add(newLocation);
        }

        public Location LocationAt(int x, int y)
        {
            foreach (Location location in _locations)
            {
                if (location.XCoordinate == x && location.YCoordinate == y) return location;
            }
            return null;
        }
    }
}
