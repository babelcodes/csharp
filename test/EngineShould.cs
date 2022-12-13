using Xunit;
using Moq;

namespace MyGame.Tests {

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

        // To test mock of property
        [Trait("Category", "Writing")]
        [Fact]
        public void AcceptValidLicenseKey() {
            var mockCharacter = new Mock<Character>();
            // mockCharacter.Setup(x => x.licenseKey).Returns("VALID");
            mockCharacter.Setup(x => x.licenseKey).Returns(GetLicenseKeyValid);

            var sut = new Engine(mockCharacter.Object);

            Assert.True(sut.Evaluate("p"));
        }

        // To test mock of property hierarchy
        [Trait("Category", "Writing")]
        [Fact]
        public void AcceptValidServiceInformationKey() {
            var mockCharacter = new Mock<Character>();
            // mockCharacter.Setup(x => x.licenseKey).Returns("VALID");
            mockCharacter.Setup(x => x.serviceInformation.license.licenseKey).Returns(GetLicenseKeyValid);

            var sut = new Engine(mockCharacter.Object);

            Assert.True(sut.Evaluate("p"));
        }

        [Trait("Category", "Writing")]
        [Fact]
        public void RejectIfAllChecksAreFalse() {
            var mockCharacter = new Mock<Character>();
            mockCharacter.DefaultValue = DefaultValue.Mock; // Prevent NullReferenceException on .serviceInformation

            var sut = new Engine(mockCharacter.Object);

            Assert.False(sut.Evaluate("p"));
        }

        private string GetLicenseKeyValid() {
            return "VALID";
        }

    }

}
