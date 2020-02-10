using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DungeonMasterData.Models
{
    public class Character
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
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

        public virtual List<Bag> Bags { get; set; }

        public Character()
        {
            Bags = new List<Bag>();
        }
    }
}
