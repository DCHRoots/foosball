# foosball
.net core rest api test

# Api methods

**Description: Get all games**

`GetGames
[HttpGet]
usage: https://localhost:44329/game`

----------------------
**Description: Get game by Id**

`GetGameById/{id}
[HttpGet]
usage: https://localhost:44329/game/1`

----------------------
**Description: Create new Game and returns that game Id**

`CreateGame
[HttpPost]
usage: https://localhost:44329/game`

----------------------
**Description: increase goal count for specified game by {gameId} and {teamName}**

**NOTE: currently there are always 2 teams 'red' and 'blue' it is not case sensitive.**

`UpdateGame/{gameId}/{teamName}
[HttpPost]
usage: https://localhost:44329/game/1/red`

