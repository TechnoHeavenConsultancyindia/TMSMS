using TMSMS.RestaurantService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.RestaurantService.csproj"); 
await builder.RunAbpModuleAsync<RestaurantServiceTestsModule>(applicationName: "TMSMS.RestaurantService");

public partial class TestProgram
{
}
