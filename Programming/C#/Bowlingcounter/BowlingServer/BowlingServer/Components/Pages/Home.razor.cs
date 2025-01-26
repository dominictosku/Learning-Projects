using Bowling.Classes;
using Bowling.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BowlingServer.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public IBowlingService BowlingService { get; set; }
        public int LastRoll { get; set; } = 0;

        protected override void OnInitialized()
        {
            ResetGame();
        }

        private void PlayRound() 
        {
            var random = new Random().Next(0, 11);
            BowlingService.PlayGame(random);
            LastRoll = random;
        }

        private void ResetGame()
        {
            var player = new Player();
            player.Name = "John Bowling";
            BowlingService.InitializeGame(player);
        }
    }
}