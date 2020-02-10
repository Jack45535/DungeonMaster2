using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{
    public interface IBagData
    {
        IEnumerable<Bag> GetAll();
        Bag Get(int id);
        void Add(Bag bag);
        void Edit(Bag bag);
        void Delete(int id);
    }
}
