using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Entities
{
    public class Shop
    {
        public List<Item> ShopInventory { get; set; }

        public void Buy(Player player, Item item)
        {
            if (player.Gold < item.Value)
            {
                Console.WriteLine("You don't have enough gold to buy that item.");
                return;
            }

            if (!ShopInventory.Contains(item))
            {
                Console.WriteLine("That item isn't for sale.");
                return;
            }

            player.Gold -= item.Value;
            ShopInventory.Remove(item);
            player.Inventory.Add(item);

            Console.WriteLine($"You bought the {item.Name} for {item.Value} gold.");
        }
        public void Sell(Player player, Item item)
        {
            if (!player.Inventory.Contains(item))
            {
                Console.WriteLine("You don't have that item.");
                return;
            }

            player.Gold += item.Value;
            player.Inventory.Remove(item);
            ShopInventory.Add(item);

            Console.WriteLine($"You sold the {item.Name} for {item.Value} gold.");
        }
    }
}
