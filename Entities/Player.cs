using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Interfaces;
using TextAdventure.Map;

namespace TextAdventure.Entities
{
    public class Player
    {
        public Player(string name, int health, int maxHealth, int gold, Continent _currentContinent, Vector2 position, List<Item> inventory)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            Gold = gold;
			CurrentContinent = _currentContinent;
            Position = position;

            Inventory = inventory;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
		public Continent CurrentContinent {get; set;}
        public Vector2 Position { get; set; }
        public List<Item> Inventory { get; set; }
    }
}
