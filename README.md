# .Net / C#

- [.Net / C#](#net--c)
  - [The language](#the-language)
  - [Source code](#source-code)
    - [Main project](#main-project)
    - [Test project](#test-project)
  - [Getting started](#getting-started)
    - [Setup](#setup)
    - [Create project](#create-project)
    - [Run project](#run-project)
    - [Edit project](#edit-project)
  - [Solution](#solution)
    - [Packages system: Nuggets](#packages-system-nuggets)
    - [Debugging](#debugging)
    - [Refactoring](#refactoring)
    - [HelloWorld](#helloworld)
  - [Unit tests](#unit-tests)


## The language

- [C# - the language](./doc/csharp.md)

## Source code

### Main project

```shell
$ cd src
$ dotnet run
```

### Test project

```shell
$ cd test
$ dotnet watch run
```


## Getting started

### Setup

On Mac:

- [.Net](https://learn.microsoft.com/en-us/dotnet/core/install/macos)
- [Visual Studio Code]()
  - C# extension
  - [Setting up Visual Studio Code](https://code.visualstudio.com/docs/setup/setup-overview)

Check:

```shell
$ dotnet --list-sdks 
```


### Create project
```shell
$ mkdir MyProject
$ cd MyProject
$ dotnet new console
```

### Run project
```shell
$ cd MyProject
$ dotnet run
$ dotnet run --project src/GradeBook/GradeBook.csproj
```

### Edit project
```shell
$ cd MyProject/..
$ code .
## Open Program.cd
```

## Solution

```shell
$ cd MyProject/
$ dotnet sln add reference src/GradeBook/GradeBook.csproj
$ dotnet sln add reference test/GradeBook.Tests/GradeBook.Tests.csproj
```


### Packages system: Nuggets

- https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli

```shell
$ dotnet add package <PACKAGE_NAME> -v <VERSION>
```

- packages called Nugets
- https://nuget.org
```shell
$ cd MyProject
$ dotnet restore ## Grab dependencies
$ dotnet build   ## Combine files and compile them in a DLL
$ dotnet bin/Debug/netcoreapp2.1/MyProject.dll
```
- DLL: Dynamic Link Language
    - An assembly is the output of a language compiler: in the `/bin` folder
    - Can be executed


### Debugging
- In Visual Studio Code > Debug > Start Debbuging
- https://app.pluralsight.com/course-player?clipId=f18927ec-476a-482a-b692-d5f3d3512fca
```shell
$ cd MyProject
$ dir .vscode
$ dir

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
d-----        10/27/2022  10:11 AM                launch.json   ## Configurations, with params
d-----         12/1/2022   1:47 PM                tasks.json
```


### Refactoring

- [Refactoring source code in Visual Studio Code](https://code.visualstudio.com/docs/editor/refactoring)



### HelloWorld

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

- [./test/README.md](./test/README.md)