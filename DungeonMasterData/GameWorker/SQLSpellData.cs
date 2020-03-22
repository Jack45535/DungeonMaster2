using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{
    public class SQLSpellData : ISpellData
    {
        private readonly GameDbContext db;

        public SQLSpellData(GameDbContext db)
        {
            this.db = db;
        }

        public void Add(Spell spell)
        {
            db.Spells.Add(spell);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var spell = db.Spells.Find(id);
            db.Spells.Remove(spell);
            db.SaveChanges();
        }

        public void Edit(Spell spell)
        {
            var entry = db.Entry(spell);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Spell Get(int id)
        {
            return db.Spells.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Spell> GetAll()
        {
            return db.Spells;
        }
    }
}
