using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.Services
{
    public class Repository : IRepository
    {
        LiteDbContext context { get; set; }
        public Repository(LiteDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            var collection = this.context.Context.GetCollection<Game>();
            return collection.FindAll().OrderByDescending(g => g.StartDate);
        }

        public async Task<Game> GetGame(int id)
        {
            var item = this.context.Context.GetCollection<Game>().FindById(id);
            return item;
        }

        public async Task<Game> AddGame(Game game)
        {
            var collection = this.context.Context.GetCollection<Game>();
            var id = collection.Insert(game);
            game.Id = id;
            return game;
        }

        public async Task<Game> UpdateGame(Game game)
        {
            var item = this.context.Context.GetCollection<Game>().FindById(game.Id);
            item.Sets = game.Sets;
            this.context.Context.GetCollection<Game>().Update(item);
            return item;
        }
    }
}
