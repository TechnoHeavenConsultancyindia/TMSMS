using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace TMSMS.IdentityService.Controllers;

[Route("api/identity/demo")]
[Area("identity")]
[RemoteService(Name = "IdentityService")]
public class DemoController : AbpController
{
    private readonly TMSMSMetrics _tMSMSMetrics;

    public DemoController(TMSMSMetrics tMSMSMetrics)
    {
        _tMSMSMetrics = tMSMSMetrics;
    }
    
    [HttpGet]
    [Route("hello")]
    public async Task<string> HelloWorld()
    {
        _tMSMSMetrics.IncrementHelloCounter();
        return await Task.FromResult("Hello World!");
    }
}