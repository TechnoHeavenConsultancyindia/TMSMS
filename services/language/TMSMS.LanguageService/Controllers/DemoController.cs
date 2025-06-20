using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace TMSMS.LanguageService.Controllers;

[Route("api/language-management/demo")]
[Area("language-management")]
[RemoteService(Name = "LanguageService")]
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