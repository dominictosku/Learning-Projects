using Bowling;

namespace Test
{
    public class TestBowlingService
    {
        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(1, 2, 2, 3)]
        [InlineData(1, 3, 3, 4)]
        [InlineData(1, 4, 10, 10)]
        // fallen pins is useless here, but it's needed for the test to run
        // currentRound is to check the incrementation of the currentFrame
        // currentFrameActual is for testing the actual result
        // currentFrameExpected is the expected result
        public void TestPlayGame_IncrementFrame(int fallenPins, byte currentRound, byte currentFrameActual, byte currentFrameExpected)
        {
            // Arrange
            var bowlingService = new BowlingService(new Player())
            {
                CurrentFrame = currentFrameActual
            };
            bowlingService.CurrentResult.Round = currentRound;

            // Act
            bowlingService.PlayGame(fallenPins);

            // Assert
            Assert.Equal(currentFrameExpected, bowlingService.CurrentFrame);
        }

        [Theory]
        [InlineData(1, 1, 1, false)] // false
        [InlineData(1, 2, 2, true)] // true
        [InlineData(1, 3, 3, true)] // true
        [InlineData(1, 4, 10, false)] // false
        public void TestPlayGame_RoundOver(int fallenPins, byte currentRound, byte currentFrame, bool lastFrameOverExpected)
        {
            // Arrange
            var bowlingService = new BowlingService(new Player())
            {
                CurrentFrame = currentFrame
            };
            bowlingService.CurrentResult.Round = currentRound;
            var lastFrame = bowlingService.CurrentResult;

            // Act
            bowlingService.PlayGame(fallenPins);

            // Assert
            Assert.Equal(lastFrameOverExpected, lastFrame.FrameOver);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(10, 10)] // Pin refill if all pins are fallen
        [InlineData(20, 10)] // More than 10, will be set to 10 (Pin refill)
        public void TestGetBowlingResult(int fallenPins, int expected)
        {
            // Arrange
            var bowlingResult = new BowlingResult(1);
            var bowlingService = new BowlingService(new Player());

            // Act
            var result = bowlingService.GetBowlingResult(bowlingResult, fallenPins);

            // Assert
            Assert.Equal(expected, result.PinsStanding);
        }   

        [Theory]
        [InlineData(10, BowlingRoll.Strike)]
        [InlineData(0, BowlingRoll.Miss)]
        [InlineData(5, BowlingRoll.Normal)]
        public void TestCheckResultForRoll(int fallenPins, BowlingRoll expected)
        {
            // Arrange
            var bowlingResult = new BowlingResult(1);
            var bowlingService = new BowlingService(new Player());

            // Act
            var result = bowlingService.CheckResultForRoll(bowlingResult, fallenPins);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestCheckResultForRoll_Spare()
        {
            // Arrange
            var bowlingResult = new BowlingResult(1);
            var bowlingService = new BowlingService(new Player());

            // Act
            bowlingResult.PinsStanding = 5;
            bowlingResult.PinsPerRound[0] = 5;
            bowlingService.CurrentResult.Round = 1; // call the result from the service
            var result = bowlingService.CheckResultForRoll(bowlingResult, 5);

            // Assert
            Assert.Equal(BowlingRoll.Spare, result);
        }   
    }
}
