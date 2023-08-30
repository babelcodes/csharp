using System;
using Xunit;

namespace TheGameOfLife/*.Tests*/
{
    public class BoardShould
    {
        [Trait("Category", "InProgress")]
        [Fact]
        public void LoadDotSynthaxBoard()
        {
            // Given
            var board = new Board(".*\n*.");

            // When

            // Then
            Assert.Equal(State.Dead, board.at(0, 0));
            Assert.Equal(State.Alive, board.at(0, 1));
            Assert.Equal(State.Alive, board.at(1, 0));
            Assert.Equal(State.Dead, board.at(1, 1));
        }

        [Theory]
        [InlineData(0, 0, State.Dead)]
        [InlineData(0, 1, State.Alive)]
        [InlineData(1, 0, State.Alive)]
        [InlineData(1, 1, State.Dead)]
        public void LoadDotSynthaxBoardTheory(int row, int column, State state)
        {
            // Given
            var board = new Board(".*\n*.");

            // When

            // Then
            Assert.Equal(state, board.at(row, column));
        }

        [Theory]
        [InlineData(0, 0, State.Dead)]
        [InlineData(0, 1, State.Dead)]
        [InlineData(0, 2, State.Dead)]
        [InlineData(0, 3, State.Alive)]
        [InlineData(1, 0, State.Alive)]
        [InlineData(1, 1, State.Dead)]
        [InlineData(1, 2, State.Dead)]
        [InlineData(1, 3, State.Alive)]
        [InlineData(2, 0, State.Dead)]
        [InlineData(2, 1, State.Alive)]
        [InlineData(2, 2, State.Alive)]
        [InlineData(2, 3, State.Dead)]
        [InlineData(3, 0, State.Dead)]
        [InlineData(3, 1, State.Dead)]
        [InlineData(3, 2, State.Dead)]
        [InlineData(3, 3, State.Dead)]
        public void LoadBiggerDotSyntaxBoard(int row, int column, State state)
        {
            // Given
            var board = new Board("...*\n*..*\n.**.\n....");

            // When

            // Then
            Assert.Equal(state, board.at(row, column));
        }

    }
}