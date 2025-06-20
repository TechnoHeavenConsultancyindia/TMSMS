using TMSMS.LanguageService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.LanguageService.csproj"); 
await builder.RunAbpModuleAsync<LanguageServiceTestsModule>(applicationName: "TMSMS.LanguageService");

public partial class TestProgram
{
}