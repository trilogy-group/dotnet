# NuGet

To create NuGet multi-target NuGet packages:

1. Open the Visual Studio Command Prompt
1. Change to the directory containing the .csproj file
1. Run (e.g.) ```msbuild /t:pack /p:Version=0.8.0 /p:Configuration=Debug```