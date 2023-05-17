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
                //            { "move", new Command { Name = "move", Execute = (player, args) => Move(args[0]) } },
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

        void Move(string argument, Player _player, Continent _currentContinent)
        {
            if (argument != null)
            {
                switch (argument.ToLower())
                {
                    case "north":
                        if (_player.Position.Y > 0) _player.Position = new Vector2(_player.Position.X, _player.Position.Y - 1);
                        break;
                    case "south":
                        if (_player.Position.Y < _currentContinent.Size.Y) _player.Position = new Vector2(_player.Position.X, _player.Position.Y + 1);
                        break;
                    case "east":
                        if (_player.Position.X < _currentContinent.Size.X) _player.Position = new Vector2(_player.Position.X + 1, _player.Position.Y);
                        break;
                    case "west":
                        if (_player.Position.X > 0) _player.Position = new Vector2(_player.Position.X - 1, _player.Position.Y);
                        break;
                    default:
                        Console.WriteLine("Invalid direction. Enter 'north', 'south', 'east', or 'west'.");
                        return;
                }
                if (_currentContinent.Locations[(int)_player.Position.X, (int)_player.Position.Y].Visited) _currentContinent.Locations[(int)_player.Position.X, (int)_player.Position.Y].Visited = true;
                Console.WriteLine(_currentContinent.Locations[(int)_player.Position.X, (int)_player.Position.Y].Description);
            }
            else Console.WriteLine("Invalid direction. Enter 'north', 'south', 'east', or 'west'.");
        }
    }
}
