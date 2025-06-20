using Volo.Abp.DependencyInjection;
using Volo.Abp.LanguageManagement.Data;
using Volo.Abp.Uow;
using Volo.Abp.MultiTenancy;

namespace TMSMS.LanguageService.Data;

public class LanguageServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<LanguageServiceDataSeeder> _logger;
    private readonly ICurrentTenant _currentTenant;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    private readonly LanguageManagementDataSeeder _languageManagementDataSeeder;

    public LanguageServiceDataSeeder(
        ILogger<LanguageServiceDataSeeder> logger,
        ICurrentTenant currentTenant,
        IUnitOfWorkManager unitOfWorkManager,
        LanguageManagementDataSeeder languageManagementDataSeeder)
    {
        _logger = logger;
        _unitOfWorkManager = unitOfWorkManager;
        _currentTenant = currentTenant;
        _languageManagementDataSeeder = languageManagementDataSeeder;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        using (_currentTenant.Change(tenantId))
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                await SeedLanguagesAsync(tenantId);
                await uow.CompleteAsync();
            }
        }
    }

    private async Task SeedLanguagesAsync(Guid? tenantId)
    {
        if (tenantId != null)
        {
            /* Language list is not multi-tenant */
            return;
        }

        await _languageManagementDataSeeder.SeedAsync();
    }
}