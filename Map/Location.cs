using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Interfaces;

namespace TextAdventure.Map
{
    public class Location
    {
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public bool Visited { get; set; }
        public Vector2 Position { get; set; }
        // Other properties...
    }
}
