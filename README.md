# Learning Cake (Make for C#)
The goal for this repository is to learn how to setup [Cake](https://cakebuild.net/) and run it for a basic console app.

For this learning tutorial I used VS Code with the Cake plugin.

I used a [video from *IAmTimCorey*](https://www.youtube.com/watch?v=ZCA4CNloep8) as inspiration to get going.

## Preconditions
You need a current version of the .NET SDK (atmy time of writing 6.0.2).
Additionally you need to have a running Node/NPM/Gulp environment.

Also it is pretty helpful to have an IDE with some kind of Cake support. Both Visual Studio and Visual Studio Code have a plugin available, which helps you writing the tasks and basic syntax.
## 1. Setup a new Solution
Execute:
`dotnet new sln`
in the parent to create the Solution

Create the folders:
```bash
App
App.Tests
```

Create the corresponding projects in `App`:
```
dotnet new console
```
and in `App.Tests`:
```
dotnet new nunit
```

Add the newly created Projects to the Solution:
```
dotnet sln add App/app.csproj
dotnet sln add App.Tests/App.Tests.csproj
```

Setup the reference in the Tests to the Project to be tested:
```
dotnet add reference ..\App\App.csproj
```

Verify that the App builds and executes from the parent folder:
```
dotnet build
dotnet test
```

## 2. Install Cake
Create a tool manifest in the solution root:
```
dotnet new tool-manifest
```

Install Cake as a local tool. At the moment of writing, 2.1.0
was the latest version:
```
dotnet tool install Cake.Tool --version 2.1.0
```

## 3. Setup a Cake build
Setup a Cake build script. For this  create a new file `build.cake` in the Solution root.

Here put in all the Tasks to be run.

After defining everything, just run it with:
```
dotnet cake
```

The result should in the end look a bit like this:
```csharp
Task                          Duration
--------------------------------------------------
Restore                       00:00:01.1089115
Build                         00:00:01.1894880
Test                          00:00:02.2252189
--------------------------------------------------
Total:                        00:00:04.5236184
```

Specific Tasks can be called directly it by its name:
```
dotnet cake --target=Build
```

Which then gives a corresponding result like this:
```csharp
Task                          Duration
--------------------------------------------------
Restore                       00:00:01.0337737
Build                         00:00:01.0871844
--------------------------------------------------
Total:                        00:00:02.1209581
```
