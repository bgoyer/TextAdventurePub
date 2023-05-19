using System.Text;
using TextAdventure.Entities;

namespace Misc
{
    public class Command
    {
        public Command(string name, Action<Player, string[]> args){
			Name = name;
			Execute = args;
		}
        public string Name { get; set; }
        public Action<Player, string[]> Execute { get; set; }
    }
}
