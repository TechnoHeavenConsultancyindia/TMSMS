using TMSMS.CommonService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.CommonService.csproj"); 
await builder.RunAbpModuleAsync<CommonServiceTestsModule>(applicationName: "TMSMS.CommonService");

public partial class TestProgram
{
}
