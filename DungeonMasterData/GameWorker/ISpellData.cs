using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{
    public interface ISpellData
    {
        IEnumerable<Spell> GetAll();
        Spell Get(int id);
        void Add(Spell spell);
        void Edit(Spell spell);
        void Delete(int id);
    }
}
