using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.Models
{
    public class Character
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public int Age { get; set; }

        public string CharDesc { get; set; }


        public int Plat { get; set; }

        public int Gold { get; set; }

        public int Silver { get; set; }

        public int Copper { get; set; }


        public int Str { get; set; }

        public int Int { get; set; }

        public int Dex { get; set; }

        public int Luck { get; set; }

        public int Speed { get; set; }

        public int Charisma { get; set; }
    }
}
