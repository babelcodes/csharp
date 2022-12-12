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