using TMSMS.FileManagementService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.FileManagementService.csproj"); 
await builder.RunAbpModuleAsync<FileManagementServiceTestsModule>(applicationName: "TMSMS.FileManagementService");

public partial class TestProgram
{
}
