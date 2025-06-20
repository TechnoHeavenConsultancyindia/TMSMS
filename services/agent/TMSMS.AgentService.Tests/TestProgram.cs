using TMSMS.AgentService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.AgentService.csproj"); 
await builder.RunAbpModuleAsync<AgentServiceTestsModule>(applicationName: "TMSMS.AgentService");

public partial class TestProgram
{
}
