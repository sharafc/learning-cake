////////////////////////////
// Initial definitions
////////////////////////////
#addin nuget:?package=Cake.Gulp&version=1.0.0
#addin nuget:?package=Cake.Npm&version=2.0.0

var target = Argument("target", "Test");
var solutionFolder = "./";
var frontentFolder = "./View";
var configuration = Argument("configuration", "Release");

////////////////////////////
// Tasks
////////////////////////////
Task("Clean")
    .Does(() =>
    {
        if (DirectoryExists("./App/bin/"))
        {
            CleanDirectory("./App/bin/");
        }
        if (DirectoryExists("./App/obj/"))
        {
            CleanDirectory("./App/obj/");
        }
        if (DirectoryExists("./publish/"))
        {
            CleanDirectory("./publish/");
        }
    });

Task("Restore")
    .Does(() =>
    {
        // Reads package.json and installs node.js packages
        NpmInstall(source => source.FromPath(frontentFolder));

        // Basic dotnet restore
        DotNetRestore(solutionFolder);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        // Executes the gulpfile.js script
        Gulp.Global.Execute(settings => settings.WithGulpFile(frontentFolder + "/gulpfile.js"));

        // Basic dotnet build
        DotNetBuild(solutionFolder, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetTest(solutionFolder, new DotNetCoreTestSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true
        });
    });

Task("Gulp")
    .IsDependentOn("Build")
    .Does(() =>
    {
        Gulp.Local.Execute();
    });

////////////////////////////
// Execution
////////////////////////////
RunTarget(target);
