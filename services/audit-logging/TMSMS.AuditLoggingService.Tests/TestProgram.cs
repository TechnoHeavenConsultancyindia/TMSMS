using TMSMS.AuditLoggingService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.AuditLoggingService.csproj"); 
await builder.RunAbpModuleAsync<AuditLoggingServiceTestsModule>(applicationName: "TMSMS.AuditLoggingService");

public partial class TestProgram
{
}
