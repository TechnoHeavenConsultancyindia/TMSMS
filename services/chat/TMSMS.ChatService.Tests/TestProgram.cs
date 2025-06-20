using TMSMS.ChatService.Tests;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("TMSMS.ChatService.csproj"); 
await builder.RunAbpModuleAsync<ChatServiceTestsModule>(applicationName: "TMSMS.ChatService");

public partial class TestProgram
{
}
