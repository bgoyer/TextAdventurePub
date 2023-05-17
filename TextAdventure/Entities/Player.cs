using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Interfaces;

namespace TextAdventure.Entities
{
    public class Player
    {
        public Player(string name, int health, int maxHealth, int gold, Vector2 position, List<Item> inventory)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            Gold = gold;
            Position = position;
            Inventory = inventory;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
        public Vector2 Position { get; set; }
        public List<Item> Inventory { get; set; }
    }
}
