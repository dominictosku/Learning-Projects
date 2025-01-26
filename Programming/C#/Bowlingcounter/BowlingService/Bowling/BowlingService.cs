using Bowling.Classes;
using Bowling.Interfaces;
using System.Threading.Tasks.Sources;

namespace Bowling
{
    public class BowlingService : IBowlingService
    {
        public BowlingService() { }

        public BowlingService(Player player)
        {
            InitializeGame(player);
        }
        public Player Player { get; set; } = new();
        public short CurrentFrame { get; set; } = 1;
        public BowlingResult CurrentResult { get; set; } = new(1);

        public void InitializeGame(Player player)
        {
            Player = player;
            CurrentFrame = 1;
            CurrentResult = GetPlayerResultForFrame(1);
        }

        public void PlayGame(int playerThrow)
        {
            if (CurrentResult.Round >= 2)
            {
                if (CurrentFrame == 10)
                {
                    return;
                }
                CurrentFrame++;
                CurrentResult.FrameOver = true;
                CurrentResult = GetPlayerResultForFrame(CurrentFrame);
                CurrentResult.Frame = CurrentFrame;
            }
            GetBowlingResult(CurrentResult, playerThrow);
        }

        public BowlingResult GetBowlingResult(BowlingResult result, int playerThrow)
        {
            if(playerThrow >= result.PinsStanding)
            {
                playerThrow = result.PinsStanding;
            }

            result.RollResultPerRound[result.Round] = CheckResultForRoll(result, playerThrow);
            result.PinsStanding -= playerThrow;
            result.PinsPerRound[result.Round] += playerThrow;
            result.Round++;

            if (result.PinsStanding <= 0)
            {
                result.PinsStanding = BowlingResult.MAXPINS;
            }

            return result;
        }

        public BowlingRoll CheckResultForRoll(BowlingResult result, int playerThrow)
        {
            if (playerThrow == 10)
            {
                return BowlingRoll.Strike;
            }

            if (playerThrow == 0)
            {
                return BowlingRoll.Miss;
            }

            if (result.PinsStanding <= playerThrow && CurrentResult.Round >= 1)
            {
                return BowlingRoll.Spare;
            }


            return BowlingRoll.Normal;
        }

        public void CreateBowlingTable()
        {
            Console.WriteLine("|-------------------------------------------------------------------|");
            Console.WriteLine("| Frame |  1  |  2  |  3  |  4  |  5  |  6  |  7  |  8  |  9  | 10  |");
            Console.WriteLine("|-------|-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|");
            Console.Write("|Points |");
            foreach (var result in Player.Results)
            {
                Console.Write(" {0}|{1} |", result.PinsPerRound[0], result.PinsPerRound[1]);
            }
            Console.WriteLine();
            Console.WriteLine("|-------------------------------------------------------------------|");
        }

        private BowlingResult GetPlayerResultForFrame(short index)
        {
            return Player.Results.FirstOrDefault(r => r.Frame == index) ?? throw new Exception("Something went wrong when creating result");
        }

    }
}