# Learning Cake (Make for C#)
The goal for this repository is to learn how to setup [Cake](https://cakebuild.net/) and run it for a basic console app.

For this learning tutorial I used VS Code with the Cake plugin.

I used a [video from *IAmTimCorey*](https://www.youtube.com/watch?v=ZCA4CNloep8) as inspiration to get going.

## Preconditions
You need a current version of the .NET SDK (atmy time of writing 6.0.2).
Also it is pretty helpful to have an IDE with some kind of Cake support. Both Visual Studio and Visual Studio Code have a plugin available, which helps you writing the tasks and basic syntax.
## 1. Setup a new Solution
Execute
`dotnet new sln`
in the parent to create our Solution

Create the folders
```bash
App
App.Tests
```

Create the corresponding projects in `App`
```
dotnet new console
```
and in `App.Tests`
```
dotnet new nunit
```

Add the newly created Projects to our Solution:
```
dotnet sln add App/app.csproj
dotnet sln add App.Tests/App.Tests.csproj
```

Setup the reference in our Tests to the Project to be tested:
```
dotnet add reference ..\App\App.csproj
```

Verify that our App builds and execute from parent:
```
dotnet build
dotnet test
```

## 2. Install Cake
Create a tool manifest in your solution root:
```
dotnet new tool-manifest
```

Install Cake as a local tool. At the moment of writing, 2.1.0
was the latest version:
```
dotnet tool install Cake.Tool --version 2.1.0
```

## 3. Setup a Cake build
Setup a Cake build script. For this we create a new file
`build.cake` in our Solution root.

Here we put in our Tasks we want to run.

After defining everything, we can just run it with:
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

If you want to call a specific Task you can just call it by its name:
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
