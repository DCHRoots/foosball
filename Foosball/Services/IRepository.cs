using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foosball.Services
{
    public interface IRepository
    {
        Task<IEnumerable<Game>> GetGames();
        Task<Game> AddGame(Game game);
        Task<Game> GetGame(int id);
        Task<Game> UpdateGame(Game game);
    }
}