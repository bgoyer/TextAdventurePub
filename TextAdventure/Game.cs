using System.Numerics;
using System.Xml.Linq;
using TextAdventure.Entities;
using TextAdventure.Interfaces;
using TextAdventure.Map;

public class Game
{
    private Player _player;
    private Dictionary<string, Action<string>> _commands;
    private Continent _currentContinent;


    public Game()
    {
        _currentContinent = new Narnia(new Vector2(100, 100));
        for (int x = 0; x < _currentContinent.Size.X; x++)
        {
            for (int y = 0; y < _currentContinent.Size.Y; y++)
            {
                _currentContinent.Locations[x, y] = new Location
                {
                    Description = $"You are at location {x}, {y}.",
                    Items = new List<Item>()
                };
            }
        }

        _commands = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "look", Look },
            { "move", Move },
            { "use", Use },
            { "take", Take },
            { "inventory", Inventory },
            {"map", DisplayMap },
            { "help", Help }
            // Add more commands here
        };
    }

    public void Start()
    {
        CreatePlayer();

        while (_player.Health > 0)
        {
            Console.WriteLine(_currentContinent.Size.X + "," + _currentContinent.Size.Y);
            Console.Write("> ");
            string input = Console.ReadLine().Trim();

            string command = input.Split(' ')[0];
            string argument = input.Contains(' ') ? input.Substring(input.IndexOf(' ')).Trim() : null;

            if (_commands.TryGetValue(command, out Action<string> action))
            {
                action(argument);
            }
            else
            {
                Console.WriteLine("I don't understand that command. Type 'help' for a list of commands.");
            }
        }

        Console.WriteLine("Game over!");
    }
    
        private void CreatePlayer()
    {
        Console.Clear();
        Console.WriteLine("Enter your name:");
        Console.Write(">");
        string name = Console.ReadLine().Trim();
       
        if (!CheckName(name)) CreatePlayer();
        else
        {
            confirmPlayerName(name);
        }
       

    }
    private void confirmPlayerName(string name)
    {
        string _input;
        Console.Clear(); 
        Console.WriteLine("Your name is " + name + "! My ears aren't what they used to be, is that correct? Y or N");
        Console.Write(">");

        _input = Console.ReadLine().Trim().ToLower();
        if (_input == "n")
            CreatePlayer();
        else if (_input == "y") 
        {
            _player = new Player(name, 10, 20, 5, new Vector2(36,32), new List<Item>()); 
            Console.Clear(); 
        }
        else confirmPlayerName(name);
    }
    private static bool CheckName(string name)
    {
        if (name == null || name == "")
        {
            return false;
        }
        return true;
    }
    
    
    private void Look(string argument)
    {
        // Implement the 'look' command
    }
    private void DisplayMap(string argument)
    {
        Console.Clear();
        for (int y = 0; y < _currentContinent.Size.Y; y++)
        {
            for (int x = 0; x < _currentContinent.Size.X; x++)
            {
                if (x == _player.Position.X && y == _player.Position.Y)
                {
                    Console.Write("P"); // P for player
                }
                else if (_currentContinent.Locations[x, y].Visited)
                {
                    Console.Write("X"); // X for visited locations
                }
                else
                {
                    Console.Write("."); // . for unvisited locations
                }
            }
            Console.WriteLine();
        }
        Console.ReadLine();
        Console.Clear();
    }
    void Move(string argument)
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

    // Other methods...
}