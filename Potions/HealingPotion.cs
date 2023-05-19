using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interfaces;

namespace Potions
{
    public class HealingPotion : Item, IUsables
    {
        public HealingPotion(string name, float weight, int value, int healValue) : base(name, $"This {name} will heal you for {healValue}", weight, value)
        {
            HealValue = healValue;
        }

        public int HealValue;
        public override void Describe()
        {
            throw new NotImplementedException();
        }

        public void Use(Player player)
        {
            if (player.Health + HealValue <= player.MaxHealth)
            {
                Console.WriteLine($"You were healed for {HealValue}!");
                player.Health += HealValue;
            }
            else
            {
                Console.WriteLine($"Your current health is {player.Health} if you heal with this potion you will waste {player.MaxHealth - player.Health} health points");
            }
        }
    }
}
