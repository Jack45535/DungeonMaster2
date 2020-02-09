using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterData.GameWorker
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Game { get; set; }

    }
}
