using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }

        public Character Character { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
