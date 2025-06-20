using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace TMSMS.SaasService.Controllers;

[Route("api/saas/demo")]
[Area("saas")]
[RemoteService(Name = "SaasService")]
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
    
    [HttpGet]
    [Route("hello-authorized")]
    [Authorize]
    public async Task<string> HelloWorldAuthorized()
    {
        return await Task.FromResult("Hello World (Authorized)!");
    }
}