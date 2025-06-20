using TMSMS.SaasService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.SaasService.csproj"); 
await builder.RunAbpModuleAsync<SaasServiceTestsModule>(applicationName: "TMSMS.SaasService");

public partial class TestProgram
{
}
