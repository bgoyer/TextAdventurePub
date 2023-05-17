using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Map
{
    public class Continent
    {
        public Continent(string name, Vector2 size) {
            Locations = new Location[(int)size.X, (int)size.Y];
        }
        public Vector2 Size;
        public Location[,] Locations;
    }
}
