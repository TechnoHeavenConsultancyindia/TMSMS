using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace TMSMS.AdministrationService.Controllers;

[Route("api/administration/demo")]
[Area("administration")]
[RemoteService(Name = "AdministrationService")]
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