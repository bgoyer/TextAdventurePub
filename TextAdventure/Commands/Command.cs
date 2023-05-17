using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Entities;

namespace TextAdventure.Misc
{
    public class Command
    {
        public string Name { get; set; }
        public Action<Player, string[]> Execute { get; set; }
    }
}
