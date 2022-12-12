using Xunit;
using Moq;

namespace MyGame.Tests {

    [Trait("Category", "Writing")]
    public class EngineShould {

        [Fact]
        public void AcceptWellNammedCharacter_withLooseMockingBehaviour() {
            Mock<Character> mockCharacter = new Mock<Character>();
            // mockCharacter.Setup(x => x.IsValid("x")).Returns(true);
            // mockCharacter.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            // mockCharacter.Setup(x => x.IsValid(It.Is<string>(number => number.StartsWith("y")))).Returns(true);
            // mockCharacter.Setup(x => x.IsValid(It.IsInRange<string>("a", "p", Moq.Range.Inclusive))).Returns(true);
            // mockCharacter.Setup(x => x.IsValid(It.IsIn("a", "b", "c"))).Returns(true);
            mockCharacter.Setup(x => x.IsValid(It.IsRegex("[a-p]"))).Returns(true);

            var sut = new Engine(mockCharacter.Object);
            Assert.True(sut.Evaluate("p"));
        }

        [Fact]
        public void AcceptWellNammedCharacter_withStrictMockingBehaviour() {
            Mock<Character> mockCharacter = new Mock<Character>(MockBehavior.Strict);
            var sut = new Engine(mockCharacter.Object);

            // Assert.False(sut.Evaluate("p"));
            Assert.Throws<Moq.MockException>(() => sut.Evaluate("p"));
        }

    }

}
