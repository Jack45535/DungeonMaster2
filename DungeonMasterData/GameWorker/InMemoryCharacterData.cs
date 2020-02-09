using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterData.Models;

namespace DungeonMasterData.GameWorker
{
    public class InMemoryCharacterData : ICharacterData
    {
        List<Character> characters;

        public void Add(Character game)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Character game)
        {
            throw new NotImplementedException();
        }

        public Character Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
