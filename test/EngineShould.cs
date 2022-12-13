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

        // ##################################################
        //
        // Mock Object Properties
        //
        // ##################################################

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
        [Fact]
        public void AcceptValidServiceInformationKey() {
            var mockCharacter = new Mock<Character>();
            // mockCharacter.Setup(x => x.licenseKey).Returns("VALID");
            mockCharacter.Setup(x => x.serviceInformation.license.licenseKey).Returns(GetLicenseKeyValid);

            var sut = new Engine(mockCharacter.Object);

            Assert.True(sut.Evaluate("p"));
        }

        private string GetLicenseKeyValid() {
            return "VALID";
        }

        // To test the update of the mock (set property on mock)
        [Fact]
        public void UpdateHealthIfRejected() {
            var mockCharacter = new Mock<Character>();
            mockCharacter.DefaultValue = DefaultValue.Mock;
            // mockCharacter.SetupProperty(x => x.health);
            mockCharacter.SetupAllProperties();

            var sut = new Engine(mockCharacter.Object);
            sut.Evaluate("p");

            Assert.Equal(10, mockCharacter.Object.health);
        }

        // To test no NullReferenceException on not set property hierarchy (.serviceInformation)
        [Fact]
        public void RejectIfAllChecksAreFalse() {
            var mockCharacter = new Mock<Character>();
            mockCharacter.DefaultValue = DefaultValue.Mock;

            var sut = new Engine(mockCharacter.Object);

            Assert.False(sut.Evaluate("p"));
        }

        // ##################################################
        //
        // Behavior Verification Tests
        //
        // ##################################################

        // To test a mock's method was called
        [Fact]
        [Trait("Category", "Writing")]
        public void CheckTheCaracterIsValid() {
            var mockCharacter = new Mock<Character>();
            mockCharacter.DefaultValue = DefaultValue.Mock;

            var sut = new Engine(mockCharacter.Object);
            sut.Evaluate("p");

            mockCharacter.Verify(x => x.IsValid("p"));
            mockCharacter.Verify(x => x.IsValid("p"), "Some message displayed on error");
            mockCharacter.Verify(x => x.IsValid(It.IsAny<string>()));

            mockCharacter.Verify(x => x.IsValid("p"), Times.Once);
            mockCharacter.Verify(x => x.IsValid("p"), Times.Exactly(1));
        }

        // To test a mock's (hierarchy) property was called
        [Fact]
        [Trait("Category", "Writing")]
        public void CheckTheCaracterLicenseKeyIsCompliant() {
            var mockCharacter = new Mock<Character>();
            mockCharacter.DefaultValue = DefaultValue.Mock;
            // mockCharacter.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var sut = new Engine(mockCharacter.Object);
            sut.Evaluate("p");

            mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey);
            mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey, "Some message displayed on error");

            mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey, Times.Once);
            mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey, Times.Exactly(1));
        }

        // To test a mock's property setter was called
        [Fact]
        [Trait("Category", "Writing")]
        public void CheckTheCaracterHealthWasUpdated() {
            var mockCharacter = new Mock<Character>();
            mockCharacter.DefaultValue = DefaultValue.Mock;

            var sut = new Engine(mockCharacter.Object);
            sut.Evaluate("p");

            mockCharacter.VerifySet(x => x.health = 10);
            mockCharacter.VerifySet(x => x.health = It.IsAny<int>());
        }

        // To test all the mock's properties was called
        [Fact]
        [Trait("Category", "Writing")]
        public void CheckAllTheCaracterProperties() {
            var mockCharacter = new Mock<Character>();
            mockCharacter.DefaultValue = DefaultValue.Mock;

            var sut = new Engine(mockCharacter.Object);
            sut.Evaluate("p");

            mockCharacter.VerifySet(x => x.health = 10);
            mockCharacter.Verify(x => x.IsValid("p"));
            mockCharacter.Verify(x => x.licenseKey, Times.Once);
            mockCharacter.Verify(x => x.serviceInformation.license.licenseKey, Times.Once);

            mockCharacter.VerifyNoOtherCalls();
        }

    }

}
