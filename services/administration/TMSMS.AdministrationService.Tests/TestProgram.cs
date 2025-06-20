using TMSMS.AdministrationService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.AdministrationService.csproj"); 
await builder.RunAbpModuleAsync<AdministrationServiceTestsModule>(applicationName: "TMSMS.AdministrationService");

public partial class TestProgram
{
}
