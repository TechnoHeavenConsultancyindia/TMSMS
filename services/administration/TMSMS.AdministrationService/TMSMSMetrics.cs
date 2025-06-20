using System.Diagnostics.Metrics;
using Volo.Abp.DependencyInjection;

namespace TMSMS.AdministrationService;

public class TMSMSMetrics : ISingletonDependency
{
    public const string MeterName = "TMSMS.Api";

    private readonly Counter<long> _helloRequestCounter;

    public TMSMSMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create(MeterName);
        _helloRequestCounter = meter.CreateCounter<long>("hello_requests.count");
    }

    public void IncrementHelloCounter()
    {
        _helloRequestCounter.Add(1);
    }
}