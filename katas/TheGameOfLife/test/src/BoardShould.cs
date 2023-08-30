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

    }
}