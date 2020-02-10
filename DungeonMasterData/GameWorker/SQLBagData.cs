using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{

    public class SQLBagData : IBagData
    {
        private readonly GameDbContext db;

        public SQLBagData(GameDbContext db)
        {
            this.db = db;
        }

        public void Add(Bag bag)
        {
            db.Bags.Add(bag);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var bag = db.Bags.Find(id);
            db.Bags.Remove(bag);
            db.SaveChanges();
        }

        public void Edit(Bag bag)
        {
            var entry = db.Entry(bag);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Bag Get(int id)
        {
            return db.Bags.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Bag> GetAll()
        {
            return db.Bags;
        }
    }
    
}
