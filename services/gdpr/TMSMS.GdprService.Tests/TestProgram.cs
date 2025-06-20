using TMSMS.GdprService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.GdprService.csproj"); 
await builder.RunAbpModuleAsync<GdprServiceTestsModule>(applicationName: "TMSMS.GdprService");

public partial class TestProgram
{
}
