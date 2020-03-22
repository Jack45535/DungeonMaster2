using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("General Description")]
        public string CharDesc { get; set; }

        [DisplayName("Platinum")]
        public int Plat { get; set; }

        public int Gold { get; set; }

        public int Silver { get; set; }

        public int Copper { get; set; }

        [DisplayName("Strength")]
        public int Str { get; set; }

        [DisplayName("Intelligence")]
        public int Int { get; set; }

        [DisplayName("Dexterity")]
        public int Dex { get; set; }

        public int Luck { get; set; }

        public int Speed { get; set; }

        public int Charisma { get; set; }

        [Required(AllowEmptyStrings = true)]
        public Background CharacterBackground { get; set; }

        public enum Background
        {

            Dragon,
            Evil,
            Mage,
            Natural,
            Ninja,
            None,
            Shaman,
            Warrior,
            Undead
        }


        public virtual List<Bag> Bags { get; set; }

        public virtual List<Spell> Spells { get; set; }

        public virtual List<Pet> Pets { get; set; }

        public Character()
        {
            Bags = new List<Bag>();
            Spells = new List<Spell>();
            Pets = new List<Pet>();
        }
    }
}
