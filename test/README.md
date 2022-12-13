# C# - Unit tests & mocks


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
```csharp
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

Mock property value of a mock object with a constant:
```c#
   mockEnemy.Setup(x => x.BossLevel).Returns("BIG");
```

Mock property value of a mock object with the result of a method:
```c#
   mockEnemy.Setup(x => x.BossLevel).Returns(GetBossLevel); // string EngineShould.GetBossLevel();
```

Mock property value for a hierarchy of properties:
```c#
   mockEnemy.Setup(x => x.CastingInformation.Hierarchy.BossLevel).Returns("BIG");
```

Mock all properties to prevent NullReferenceException:
```c#
   mockEnemy.DefaultValue = DefaultValue.Mock;
```

Keep the modification of a property of the mock (eg the `Health`):
```c#
   mockEnemy.SetupProperty(x => x.Health);
```

Keep the modification of all the properties of the mock (be aware of the place of this line in the code):
```c#
   mockEnemy.SetupAllProperties();
```

### 5. Implementng Behavior Verification Tests

Verify a mock's method was called:
```c#
   mockCharacter.Verify(x => x.IsValid("p"));
   mockCharacter.Verify(x => x.IsValid(It.IsAny<string>()));
   mockCharacter.Verify(x => x.IsValid("p"), Times.Exactly(1));
```

Verify a mock's property was get:
```c#
   mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey);
   mockCharacter.VerifyGet(x => x.serviceInformation.license.licenseKey, Times.Exactly(1));
```

Verify a mock's property was set:
```c#
   mockCharacter.VerifySet(x => x.health = 10);
   mockCharacter.VerifySet(x => x.health = It.IsAny<int>());
```

Verify all properties calls on a mock:
```c#
   // ...
   mockCharacter.VerifyNoOtherCalls();
```
