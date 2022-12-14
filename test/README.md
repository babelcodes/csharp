# C# - Unit tests & mocks

- [C# - Unit tests \& mocks](#c---unit-tests--mocks)
  - [Create tests project](#create-tests-project)
  - [Testing](#testing)
    - [Accessible target](#accessible-target)
    - [Refactoring for testing](#refactoring-for-testing)
  - [Continuous Testing](#continuous-testing)
    - [Watch tests](#watch-tests)
    - [Watch writing tests](#watch-writing-tests)
  - [Mock](#mock)
    - [4. Configuring Mock Object Properties](#4-configuring-mock-object-properties)
    - [5. Implementng Behavior Verification Tests](#5-implementng-behavior-verification-tests)


## Create tests project

- [Organizing and testing projects with the .NET CLI - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/tutorials/testing-with-cli)

```shell
$ mkdir test
$ cd test
$ dotnet new xunit
$ dotnet add reference ../hello-world.csproj
$ dotnet test
```

**WARNING** to create prod and test projects near, but not nested (test project under prod project).










## Testing
- https://nuget.org/packages/xunit

```shell
$ cd MyProject/tests
$ mkdir GradeBook.Tests
$ cd GradeBook.Tests
$ dotnet new xunit
$ dotnet add package yunit --version 2.4.1
```

Test case skeleton:
```csharp
using System;
using Xunit;

namespace GradeBook.Tests {
    public class BookTests {
        [Fact]
        public void Test1() {

        }
    }
}
```

Run tests:
```shell
$ dotnet test
```

Test assertions:
```csharp
        [Fact] // Attribute
        public void Test1() {
            // ARRANGE
            var x = 5;
            var y = 5;
            var expected = 7;

            // ACT
            var actual = x + y;

            // ASSERT
            Assert.Equal(expected, actual);
        }
```

### Accessible target

```shell
$ cd MyProject/tests/GradeBook.Tests
$ dotnet add reference ../../src/GradeBook/GradeBook.csproj
```

```csharp
using System.Collections.Generic;

namespace GradeBook {
    public class Book { // Add public modifier
        ...
    }
}
```

### Refactoring for testing

```csharp
        [Fact] // Attribute
        public void BookCalculatesAnAverageGrade() {
            // ARRANGE
            var book = new Book("B");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // ACT
            var stats = book.GetStatistics();

            // ASSERT
            Assert.Equal(85.6, stats.Average, 1);
            Assert.Equal(85.6, stats.High);
            Assert.Equal(77.3, stats.Low);
        }
```











## Continuous Testing

### Watch tests

To re-run tests each time a file is saved:
```shell
$ cd test
$ dotnet test
```

### Watch writing tests

To run only some tests, for example the ones we are weriting, we can use the `Trait` attribute to define a category.

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
