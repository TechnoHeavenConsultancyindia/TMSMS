using TMSMS.TransferService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.TransferService.csproj"); 
await builder.RunAbpModuleAsync<TransferServiceTestsModule>(applicationName: "TMSMS.TransferService");

public partial class TestProgram
{
}
