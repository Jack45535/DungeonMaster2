using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string GameMaster { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastOpened { get; set; }


        public virtual List<Character> Characters { get; set; }

        public Game()
        {
            Characters = new List<Character>();
        }
    }
}
