using TMSMS.TourService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.TourService.csproj"); 
await builder.RunAbpModuleAsync<TourServiceTestsModule>(applicationName: "TMSMS.TourService");

public partial class TestProgram
{
}
