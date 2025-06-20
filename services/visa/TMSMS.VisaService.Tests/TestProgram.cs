using TMSMS.VisaService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.VisaService.csproj"); 
await builder.RunAbpModuleAsync<VisaServiceTestsModule>(applicationName: "TMSMS.VisaService");

public partial class TestProgram
{
}
