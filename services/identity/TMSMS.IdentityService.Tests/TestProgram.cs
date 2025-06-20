using TMSMS.IdentityService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.IdentityService.csproj"); 
await builder.RunAbpModuleAsync<IdentityServiceTestsModule>(applicationName: "TMSMS.IdentityService");

public partial class TestProgram
{
}
