using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Interfaces
{
    public abstract class Item
    {
        public Item(string name, string description, float weight, int value)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Value { get; set; }

        public abstract void Describe();

    }
}
