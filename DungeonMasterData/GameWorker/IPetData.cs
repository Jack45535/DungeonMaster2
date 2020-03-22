using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{
    public interface IPetData
    {
        IEnumerable<Pet> GetAll();
        Pet Get(int id);
        void Add(Pet pet);
        void Edit(Pet pet);
        void Delete(int id);
    }
}
