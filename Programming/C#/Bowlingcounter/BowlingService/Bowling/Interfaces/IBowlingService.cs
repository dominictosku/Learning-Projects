using Bowling.Classes;

namespace Bowling.Interfaces
{
    public interface IBowlingService
    {
        short CurrentFrame { get; set; }
        BowlingResult CurrentResult { get; set; }
        Player Player { get; set; }
        void InitializeGame(Player player);
        void CreateBowlingTable();
        BowlingResult GetBowlingResult(BowlingResult result, int playerThrow);
        void PlayGame(int playerThrow);
    }
}