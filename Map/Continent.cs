using System.Numerics;
using System.Text;
using Misc;

namespace Map
{
    public class Continent
    {
        public Continent(string name, Vector2 size)
        {
            Size = size;
            Locations = new Location[(int)size.X, (int)size.Y];
        	Name = name;
		}

        public Vector2 Size { get;}
        public Location[,] Locations { get;}
		public string Name {get;}
    }
}
