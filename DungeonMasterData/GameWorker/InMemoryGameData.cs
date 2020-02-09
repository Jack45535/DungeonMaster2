using DungeonMasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonMasterData.GameWorker
{
    public class InMemoryGameData : IGameData
    {
        List<Game> games;

        public InMemoryGameData()
        {
            games = new List<Game>()
                {
                    new Game { Id= 1, Name = "Dungeon of Nature", GameMaster = "Mr. Anderson", DateCreated = DateTime.Now, DateLastOpened = DateTime.Now},
                    new Game { Id= 2, Name = "Dungeon of Water", GameMaster = "Neo", DateCreated = DateTime.Now, DateLastOpened = DateTime.Now},
                    new Game { Id= 3, Name = "Dungeon of Earth", GameMaster = "Trinity", DateCreated = DateTime.Now, DateLastOpened = DateTime.Now},
                    new Game { Id= 4, Name = "Dungeon of Fire", GameMaster = "Steve", DateCreated = DateTime.Now, DateLastOpened = DateTime.Now}
                };
        }

        public void Edit(Game game)
        {
            var existing = Get(game.Id);
            if (existing != null)
            {
                existing.Name = game.Name;
                existing.GameMaster = game.GameMaster;
                existing.DateCreated = game.DateCreated;
                existing.DateLastOpened = game.DateLastOpened;
            }
        }


        public void Add(Game game)
        {
            games.Add(game);
            game.Id = games.Max(g => g.Id) + 1;
        }

        public Game Get(int id)
        {
            return games.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return games.OrderBy(g => g.Name);
        }

        public void Delete(int id)
        {
            var game = Get(id);
            if (games != null)
            {
                games.Remove(game);
            }
        }
    }
}
