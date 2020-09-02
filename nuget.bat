dotnet test .\Structurizr.Core.Tests\Structurizr.Core.Tests.csproj
dotnet test .\Structurizr.Client.Tests\Structurizr.Client.Tests.csproj

dotnet msbuild "/t:rebuild;pack" /p:Version=0.9.7 /p:Configuration=Debug .\Structurizr.Core\Structurizr.Core.csproj
dotnet msbuild "/t:rebuild;pack" /p:Version=0.9.7 /p:Configuration=Debug .\Structurizr.Client\Structurizr.Client.csproj