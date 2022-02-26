////////////////////////////
// Initial definitions
////////////////////////////
var target = Argument("target", "Test");
var solutionFolder = "./";
var configuration = Argument("configuration", "Release");

////////////////////////////
// Tasks
////////////////////////////
Task("Restore")
    .Does(() =>
    {
        DotNetRestore(solutionFolder);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
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

////////////////////////////
// Execution
////////////////////////////
RunTarget(target);
