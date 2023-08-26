# .Net / C# - HelloWorld

Table of content:
* [HelloWorld](#helloworld)
* [Main project](#main-project)
* [Test project](#test-project)
* [Create project](#create-project)
* [Run project](#run-project)
* [Edit project](#edit-project)
* [Debugging](#debugging)

## HelloWorld

- [Create a .NET console application using Visual Studio Code - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-7-0)
- [Créer une application console .NET à l’aide de Visual Studio pour Mac - .NET | Microsoft Learn](https://learn.microsoft.com/fr-fr/dotnet/core/tutorials/with-visual-studio-mac)
- [Modifications du modèle d’application console C# dans .NET 6+ - .NET | Microsoft Learn](https://aka.ms/new-console-template)

```shell
$ mkdir hello-world
$ cd hello-world
$ code .              # Open VS Code from that project directory
                      # Show all commands: SHIFT + COMMAND + P
                      # >Shell Command: Install 'code' command in PATH
$ dotnet new console --framework net7.0
# OR
$ dotnet new console -o hello-world
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
$ dotnet watch run
```

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

## Create project
```shell
$ mkdir MyProject
$ cd MyProject
$ dotnet new console
```

## Run project
```shell
$ cd MyProject
$ dotnet run
$ dotnet run --project src/GradeBook/GradeBook.csproj
```

## Edit project
```shell
$ cd MyProject/..
$ code .
## Open Program.cd
```

## Debugging
- In Visual Studio Code > Debug > Start Debugging
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
