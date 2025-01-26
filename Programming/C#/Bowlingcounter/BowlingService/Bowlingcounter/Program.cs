using Bowling;
using Bowling.Classes;

var player = new Player();
var game = new BowlingService(player);

game.PlayGame(4);

game.CreateBowlingTable();
