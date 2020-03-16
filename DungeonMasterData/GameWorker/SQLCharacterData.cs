using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterData.Models;

namespace DungeonMasterData.GameWorker
{
    public class SQLCharacterData : ICharacterData
    {
        private readonly GameDbContext db;

        public SQLCharacterData(GameDbContext db)
        {
            this.db = db;
        }

        public void Add(Character character)
        {
            db.Characters.Add(character);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var character = db.Characters.Find(id);
            db.Characters.Remove(character);
            db.SaveChanges();
        }

        public void Edit(Character character)
        {
            var entry = db.Entry(character);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Character Get(int id)
        {
            return db.Characters.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Character> GetAll()
        {
            return db.Characters.Include("Bags");
        }
    }
}
