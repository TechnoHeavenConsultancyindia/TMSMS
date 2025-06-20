using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TMSMS.AuthServer;

[Dependency(ReplaceServices = true)]
public class BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TMSMS Authentication Server";
}