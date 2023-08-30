# C# - Unit tests & mocks

- [C# - Unit tests \& mocks](#c---unit-tests--mocks)
  - [Create test project](#create-test-project)
  - [Run tests](#run-tests)
  - [Continuous Testing](#continuous-testing)
  - [My first test case](#my-first-test-case)
  - [Skip with a reason](#skip-with-a-reason)
  - [Grouping with Traits](#grouping-with-traits)
  - [Watch writing tests](#watch-writing-tests)
  - [Data driven with Theory](#data-driven-with-theory)
  - [Setup in the constructor](#setup-in-the-constructor)
  - [Teardown in the destructor](#teardown-in-the-destructor)
  - [Mock](#mock)
    - [4. Configuring Mock Object Properties](#4-configuring-mock-object-properties)
    - [5. Implementng Behavior Verification Tests](#5-implementng-behavior-verification-tests)


## Create test project

- [Organizing and testing projects with the .NET CLI - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/tutorials/testing-with-cli)
- https://nuget.org/packages/xunit

```shell
$ cd MyProject/tests
$ mkdir MyProject.Tests
$ cd MyProject.Tests
$ dotnet new xunit
$ dotnet add reference ../../src/MyProject/my-project.csproj       # Accessible target
$ dotnet add package xunit --version 2.4.1
```

**WARNING** to create prod and test projects near, but not nested (test project under prod project).



## Run tests

Run tests:

```shell
$ cd MyProject/tests/MyProject.Tests
$ dotnet test
```



## Continuous Testing

To automatically run tests each time a file is saved use the `watch` option:

```shell
$ dotnet watch test
```



## My first test case

```c#
using System;
using Xunit                            // 1/3 - Xunit import

namespace GameEngine.Tests
{
    public class BossEnemyShould       // 2/3 - Class name ends with Should
    {
        [Fact]                         // 3/3 - Add the Fact attribute
        public void HaveCorrectPower()
        {                                                    // AAA model:
            PlayerCharacter tested = new PlayerCharacter();  // - Arrange
            tested.FirstName = "Bruce";                      // - Act
            Assert.Equal("Bruce", tested.FullName);          // - Assert
        }
    }
}
```



## Skip with a reason

With the `Skip` option of the `Fact` attribute:

```c#
    public class BossEnemyShould
    {
        [Fact(Skip = "The dependency is not yet available!")]
        public void HaveCorrectPower()
        {}
    }
```



## Grouping with Traits

With the sympbol `[Trait("OneName", "OneValue")]` on a test method:

```c#
    public class BossEnemyShould
    {
        [Fact]
        [Trait("MyCategory", "Enemy")]
        [Trait("MyCategory", "Boss")]
        public void HaveCorrectPower()
        {}
    }
```

Then we can filter on run:

```shell
$ dotnet test --filter MyCategory=Enemy
```



## Watch writing tests

To run only some tests, for example the ones we are writing, we can use the `Trait` attribute to define a category.

For a test class or method:

```cs
    [Trait("Category", "Writing")] // Should be removed before commit!
    public void AcceptWellNammedCharacter() {
        ...
        Assert.True(...);
    }
```

Then update the CLI command:

```shell
$ dotnet watch test --filter Category=Writing
```



## Data driven with Theory

```c#
    public class BossEnemyShould
    {
        [Fact]
        public void HaveMinimumHealth()
        {
            _tested.TakeDamage(101);                       // 2/3 - Act
            Assert.Equal(1, _tested.Health);               // 3/3 - Assert
        }

        [Theory]                                // 1/2 - Use Theory attribute
        [InlineData(0, 100)]                    // 2/2 - Combine with InlineData attribute
        [InlineData(1, 99)]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _tested.TakeDamage(damage);                    // 2/3 - Act
            Assert.Equal(expectedHealth, _tested.Health);  // 3/3 - Assert
        }
    }
```



## Setup in the constructor

```c#
    public class BossEnemyShould
    {
        private readonly PlayerCharacter _tested;    // 1/3. Declare properties

        public BossEnemyShould()                     // 2/3. Define properties in Ctor
        {
            _tested = new PlayerCharacter();
        }

        [Fact]
        public void HaveCorrectPower()
        {                                            // 3/3. Remove definitions in testcase
            // PlayerCharacter tested = new PlayerCharacter();
            _tested.FirstName = "Bruce";
            Assert.Equal("Bruce", _tested.FullName)
        }
    }
```



## Teardown in the destructor

```c#
    public class BossEnemyShould : IDisposable      // 1/2. Implement interface
    {
        public void Dispose()                       // 2/2. Overload method for cleanup
        {
            // Cleanup
        }

        [Fact]
        public void HaveCorrectPower()
        {}
    }
```




## Mock

### 4. Configuring Mock Object Properties

- Code source: [EngineShould.cs](./EngineShould.cs)

Mock property value of a mock object with a constant:
```cs
   mockEnemy.Setup(x => x.BossLevel).Returns("BIG");
```

Mock property value of a mock object with the result of a method:
```cs
   mockEnemy.Setup(x => x.BossLevel).Returns(GetBossLevel); 
   // string EngineShould.GetBossLevel();
```

Mock property value for a hierarchy of properties:
```cs
   mockEnemy.Setup(x => x.CastingInformation.Hierarchy.BossLevel).Returns("BIG");
```

Mock all properties to prevent NullReferenceException:
```cs
   mockEnemy.DefaultValue = DefaultValue.Mock;
```

Keep the modification of a property of the mock (eg the `Health`):
```cs
   mockEnemy.SetupProperty(x => x.Health);
```

Keep the modification of all the properties of the mock (be aware of the place of this line in the code):
```cs
   mockEnemy.SetupAllProperties();
```

### 5. Implementng Behavior Verification Tests

- Code source: [EngineShould.cs](./EngineShould.cs)

Verify a mock's method was called:
```cs
   mockCharacter.Verify(x => x.IsValid("p"));
   mockCharacter.Verify(x => x.IsValid(It.IsAny<string>()));
   mockCharacter.Verify(x => x.IsValid("p"), Times.Exactly(1));
```

Verify a mock's property was get:
```cs
   mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey);
   mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey, Times.Exactly(1));
```

Verify a mock's property was set:
```cs
   mockCharacter.VerifySet(x => x.health = 10);
   mockCharacter.VerifySet(x => x.health = It.IsAny<int>());
```

Verify all properties calls on a mock:
```cs
   // ...
   mockCharacter.VerifyNoOtherCalls();
```