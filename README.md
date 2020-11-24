# foosball
.net core rest api test

#Api methods

`GetGames
[HttpGet]
usage: https://localhost:44329/game`
Description: Get all games

`GetGameById/{id}
[HttpGet]
usage: https://localhost:44329/game/1`
Description: Get game by Id

`CreateGame
[HttpPost]
usage: https://localhost:44329/game`
Description: Create new Game and returns that game Id

`UpdateGame/{gameId}/{teamName}
[HttpPost]
usage: https://localhost:44329/game/1/red`
Description: increase goal count for specified game by {gameId} and {teamName} 
NOTE: currently there are always 2 teams 'red' and 'blue' it is not case sensitive.
