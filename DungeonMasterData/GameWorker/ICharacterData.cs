using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{
    public interface ICharacterData
    {
        IEnumerable<Character> GetAll();
        Character Get(int id);
        void Add(Character character);
        void Edit(Character character);
        void Delete(int id);
    }
}
