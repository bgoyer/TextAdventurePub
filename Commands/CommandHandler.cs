using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Entities;
using TextAdventure.Map;
using TextAdventure.Misc;

namespace TextAdventure.Commands
{
    public class CommandHandler
    {
        private Dictionary<string, Command> _commands;

        public CommandHandler()
        {	
			_commands = new Dictionary<string, Command>
            {
                { "move", new Command("move", Move) },
				{ "quit", new Command("quit", Quit) },
				
                // Add more commands here...
            };
        }

        public void HandleCommand(string input, Player player)
        {
            string[] parts = input.Split(' ');
            string commandName = parts[0];
            string[] args = parts.Skip(1).ToArray();

            if (_commands.TryGetValue(commandName, out Command command))
            {
                command.Execute(player, args);
            }
            else
            {
                Console.WriteLine($"Unknown command: {commandName}");
            }
        }
		
		void Quit(Player _player, params string[] args)
		{
			Environment.Exit(0);
		}
		
		private void Potion(string argument)
    	{
 		//HealingPotion smallHealingPotion = new HealingPotion("Small Health Potion", 0.1f, 10, 10);
 		//smallHealingPotion.Use(_player);
    	}
		
   	     private void Look(string argument)
   	    {
        // Implement the 'look' command
    	}
		
    void Move(Player _player, string[] args)
    {
        if (args[0] != null)
        {
            switch (args[0])
            {
                case "north":
                    if (_player.Position.Y > 0) _player.Position = new Vector2(_player.Position.X, _player.Position.Y - 1);
                    break;
                case "south":
                    if (_player.Position.Y < _player.CurrentContinent.Size.Y) _player.Position = new Vector2(_player.Position.X, _player.Position.Y + 1);
                    break;
                case "east":
                    if (_player.Position.X < _player.CurrentContinent.Size.X) _player.Position = new Vector2(_player.Position.X + 1, _player.Position.Y);
                    break;
                case "west":
                    if (_player.Position.X > 0) _player.Position = new Vector2(_player.Position.X - 1, _player.Position.Y);
                    break;
                default:
                    Console.WriteLine("Invalid direction. Enter 'north', 'south', 'east', or 'west'.");
                    return;
            }
            if (_player.CurrentContinent.Locations[(int)_player.Position.X, (int)_player.Position.Y].Visited) _player.CurrentContinent.Locations[(int)_player.Position.X, (int)_player.Position.Y].Visited = true;
            Console.WriteLine(_player.CurrentContinent.Locations[(int)_player.Position.X, (int)_player.Position.Y].Description);
        }
        else Console.WriteLine("Invalid direction. Enter 'north', 'south', 'east', or 'west'.");
    }
    private void Exit(string argument){
		Environment.Exit(1);
	}
    private void Use(string argument)
    {
        // Implement the 'use' command
    }

    private void Take(string argument)
    {
        // Implement the 'take' command
    }

    private void Inventory(string argument)
    {
        // Implement the 'inventory' command
    }

    private void Help(string argument)
    {
        // Implement the 'help' command
    }
	}
}