using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{
    public class SQLPetData : IPetData
    {
        private readonly GameDbContext db;

        public SQLPetData(GameDbContext db)
        {
            this.db = db;
        }

        public void Add(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
            db.SaveChanges();
        }

        public void Edit(Pet pet)
        {
            var entry = db.Entry(pet);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Pet Get(int id)
        {
            return db.Pets.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Pet> GetAll()
        {
            return db.Pets;
        }
    }
}
