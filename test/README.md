# C# - Unit tests & mocks


## Create tests project

- [Organizing and testing projects with the .NET CLI - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/tutorials/testing-with-cli)

```shell
$ mkdir test
$ cd test
$ dotnet new xunit
$ dotnet add reference ../hello-world.csproj
$ dotnet watch test
```

**WARNING** to create prod and test projects near, but not nested (test project under prod project).

## Continuous Testing

For a test class or method:
```csharp
    [Trait("Category", "Writing")] // Should be removed before commit!
    public void AcceptWellNammedCharacter() {
        ...
        Assert.True(...);
    }
```

In the CLI:
```shell
$ dotnet watch test --filter Category=Writing
```