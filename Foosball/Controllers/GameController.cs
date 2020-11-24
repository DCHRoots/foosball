using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foosball.Services;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foosball.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly ILogger<GameController> logger;
        private IRepository repository;

        public GameController(ILogger<GameController> logger, IRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> Get()
        {
            return await this.repository.GetGames();
        }


        [HttpGet("{id}")]
        public async Task<Game> GetById(int id)
        {
            return await this.repository.GetGame(id);
        }

        [HttpPost]
        public async Task<Game> Create()
        {
            var now = DateTime.Now;
            Game game = new Game()
            {
                Sets = new List<Set>()
                {
                    new Set(){
                        StartDate = now,
                        Team = new Team()
                        {
                            Name = "red"
                        },
                        Goals = new List<Goal>()
                    },
                    new Set(){
                        StartDate = now,
                        Team = new Team()
                        {
                            Name = "blue"
                        },
                        Goals = new List<Goal>()
                    }
                }
            };

            return await this.repository.AddGame(game);
        }

        [HttpPost("{gameId}/{team}")]
        public async Task<Game> Update(int gameId, string team)
        {
            var game = await this.repository.GetGame(gameId);
            CheckIfGameFinished(game);

            var set = game.Sets.LastOrDefault(s => s.Team.Name == team);
            if (set == null)
                throw new Exception("Team with specified name does not exists");

            if (set.Goals.Count < 11)
            {
                set.Goals.Add(new Goal(DateTime.Now));
            }

            if(set.Goals.Count == 11)
            {
                CheckIfGameFinished(game);

                game.Sets.Add(new Set()
                {
                    StartDate = DateTime.Now,
                    Team = new Team()
                    {
                        Name = team
                    },
                    Goals = new List<Goal>()
                });
            }

            return await this.repository.UpdateGame(game);
        }

        private static void CheckIfGameFinished(Game game)
        {
            var team1 = "red";
            if ((game.Sets.Count(s => s.Team.Name == team1) >= 2 && game.Sets.Count(s => s.Team.Name == team1 && s.Goals.Count == 11) >= 2))
                throw new Exception($"This game is already finished. Team {team1} has won.");

            var team2 = "blue";
            if ((game.Sets.Count(s => s.Team.Name == team2) >= 2 && game.Sets.Count(s => s.Team.Name == team2 && s.Goals.Count == 11) >= 2))
                throw new Exception($"This game is already finished. Team {team2} has won.");
        }
    }
}
