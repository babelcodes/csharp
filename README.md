# TryConsole

## Main project

```shell
$ cd src
$ dotnet run
```

## Test project

```shell
$ cd test
$ dotnet watch run
```


# Getting started

## Setup

On Mac:

- [.Net](https://learn.microsoft.com/en-us/dotnet/core/install/macos)
- [Visual Studio Code]()
  - C# extension
  - [Setting up Visual Studio Code](https://code.visualstudio.com/docs/setup/setup-overview)

Check:

```shell
$ dotnet --list-sdks 
```



## Nuggets

- https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli

```shell
$ dotnet add package <PACKAGE_NAME> -v <VERSION>
```


## Refactoring

- [Refactoring source code in Visual Studio Code](https://code.visualstudio.com/docs/editor/refactoring)



## HelloWorld

- [Create a .NET console application using Visual Studio Code - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-7-0)

```shell
$ mkdir hello-world
$ cd hello-world
$ dotnet new console --framework net7.0
```

And then replace the content of `/Program.cs` with the following content:

```c#
namespace HelloWorld {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

And finally run the app:

```shell
$ dotnet run
```



## Unit tests

- [Organizing and testing projects with the .NET CLI - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/tutorials/testing-with-cli)

```shell
$ mkdir test
$ cd test
$ dotnet new xunit
$ dotnet add reference ../hello-world.csproj
$ dotnet watch test
```


### Continuous Testing

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