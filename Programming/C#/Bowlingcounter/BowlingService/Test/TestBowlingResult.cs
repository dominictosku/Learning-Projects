namespace Test
{
    public class TestBowlingResult
    {
        [Theory]
        [InlineData("O", BowlingRoll.Miss)]
        [InlineData("▶◀", BowlingRoll.Strike)]
        [InlineData("◢", BowlingRoll.Spare)]
        [InlineData("5", BowlingRoll.Normal)]
        public void TestGetSymbolForBowlingRoll(string expected, BowlingRoll bowlingRoll)
        {
            // Arrange
            var bowlingScoreboard = new BowlingResult(1)
            {
                RollResultPerRound = [bowlingRoll],
                PinsPerRound = [5]
            };

            // Act
            var symbol = bowlingScoreboard.GetSymbolForBowlingRoll(0);

            // Assert
            Assert.Equal(expected, symbol);
        }
    }
}