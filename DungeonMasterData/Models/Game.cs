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
        public string Name { get; set; }

        [Required]
        public string GameMaster { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastOpened { get; set; }
    }
}
