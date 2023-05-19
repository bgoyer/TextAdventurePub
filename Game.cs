using System.Numerics;
using System.Xml.Linq;
using TextAdventure.Entities;
using TextAdventure.Interfaces;
using TextAdventure.Map;
using TextAdventure.Misc;
using TextAdventure.Commands;
using TextAdventure.Potions;

public class Game
{
    private Player _player;
    private Continent _currentContinent;
	private CommandHandler _commandHandler;
    private int _currentContinent_Size = 100;

    public Game()
    {
		_commandHandler = new CommandHandler();
        _currentContinent = new Narnia(new Vector2(100, 100));
        for (int x = 0; x < _currentContinent.Size.X; x++)
        {
            for (int y = 0; y < _currentContinent.Size.Y; y++)
            {
                _currentContinent.Locations[x,y] = new Location
                {
                    Description = $"You are at location {x}, {y}.",
                    Items = new List<Item>()
                };
            }
        } 
    }

    public void Start()
    {
        CreatePlayer();

        while (_player.Health > 0)
        {
            Console.Clear();
            DisplayMap(_player);
			string input = Input();
			_commandHandler.HandleCommand(input, _player);
		}

        Console.WriteLine("Game over!");
    }
    
        private void CreatePlayer()
    {
        Console.Clear();
        string name = Input();
        if (!CheckName(name)) CreatePlayer();
        else
        {
            confirmPlayerName(name);
        }
       

    }
    private void DisplayMap(Player _player)
    {
        for (int y = _player.Position.Y - 10 > 0 ? (int)_player.Position.Y - 10 : 0; y < (_player.Position.Y - 10 > 0 ? (int)_player.Position.Y + 10 : 10); y++)
        {
            for (int x = _player.Position.X - 10 > 0 ? (int)_player.Position.X - 10 : 0; x < (_player.Position.X - 10 > 0 ? (int)_player.Position.X + 10 : 10); x++)
            {
                if (x == _player.Position.X && y == _player.Position.Y)
                {
                    Console.Write("P"); // P for player
                }
                else if (_player.CurrentContinent.Locations[x, y].Visited)
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
    }
    private string Input()
	{
		Console.Write(">");
		return Console.ReadLine().Trim();
	}
    private void confirmPlayerName(string name)
    {
        string _input;
        Console.Clear(); 
        Console.WriteLine("Your name is " + name + " you say? My ears aren't what they used to be. (Y/N)");
        _input = Console.ReadLine().Trim().ToLower();
        if (_input == "n")
            CreatePlayer();
        else if (_input == "y") 
        {
            _player = new Player(name, 10, 15, 5, _currentContinent, new Vector2(36,32), new List<Item>()); 
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
}
    