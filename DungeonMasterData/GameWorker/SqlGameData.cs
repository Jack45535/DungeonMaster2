using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterData.Models;


namespace DungeonMasterData.GameWorker
{
    public class SqlGameData : IGameData
    {
        private readonly GameDbContext db;

        public SqlGameData(GameDbContext db)
        {
            this.db = db;
        }
        public void Add(Game game)
        {
            db.Game.Add(game);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = db.Game.Find(id);
            db.Game.Remove(game);
            db.SaveChanges();
        }

        public void Edit(Game game)
        {
            var entry = db.Entry(game);
            entry.State = EntityState.Modified;
            db.SaveChanges();
            
        }

        public Game Get(int id)
        {
            return db.Game.FirstOrDefault(g => g.Id == id);

        }

        public IEnumerable<Game> GetAll()
        {
            return db.Game.Include("Characters");
        }
    }
}
