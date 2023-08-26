# .Net / C# - Solution

Table of content:
* [Solution](#solution)
* [Packages system: Nuggets](#packages-system-nuggets)


## Solution

```shell
$ cd MyProject/
$ dotnet sln add reference src/GradeBook/GradeBook.csproj
$ dotnet sln add reference test/GradeBook.Tests/GradeBook.Tests.csproj
```


## Packages system: Nuggets

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
