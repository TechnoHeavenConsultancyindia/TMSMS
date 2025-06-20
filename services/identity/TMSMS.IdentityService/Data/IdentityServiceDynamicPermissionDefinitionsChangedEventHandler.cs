using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace TMSMS.IdentityService.Data;

public class IdentityServiceDynamicPermissionDefinitionsChangedEventHandler : IDistributedEventHandler<DynamicPermissionDefinitionsChangedEto>, ITransientDependency
{
    protected IPermissionDefinitionManager PermissionDefinitionManager { get; }
    protected IPermissionDataSeeder PermissionDataSeeder { get; }
    protected IDynamicPermissionDefinitionStoreInMemoryCache DynamicPermissionDefinitionStoreInMemoryCache { get; }

    public ILogger<IdentityServiceDynamicPermissionDefinitionsChangedEventHandler> Logger { get; set; }

    public IdentityServiceDynamicPermissionDefinitionsChangedEventHandler(
        IPermissionDefinitionManager permissionDefinitionManager,
        IPermissionDataSeeder permissionDataSeeder,
        IDynamicPermissionDefinitionStoreInMemoryCache dynamicPermissionDefinitionStoreInMemoryCache)
    {
        PermissionDefinitionManager = permissionDefinitionManager;
        PermissionDataSeeder = permissionDataSeeder;
        DynamicPermissionDefinitionStoreInMemoryCache = dynamicPermissionDefinitionStoreInMemoryCache;

        Logger = NullLogger<IdentityServiceDynamicPermissionDefinitionsChangedEventHandler>.Instance;
    }

    public virtual async Task HandleEventAsync(DynamicPermissionDefinitionsChangedEto eventData)
    {
        // Clear cache
        DynamicPermissionDefinitionStoreInMemoryCache.LastCheckTime = null;
        DynamicPermissionDefinitionStoreInMemoryCache.CacheStamp = Guid.NewGuid().ToString();

        var permissionDefinitions = new List<PermissionDefinition>();
        foreach (var permission in eventData.Permissions)
        {
            var permissionDefinition = await PermissionDefinitionManager.GetOrNullAsync(permission);
            if (permissionDefinition == null)
            {
                Logger.LogWarning($"Permission {permission} is not found in the permission definition manager.");
                continue;
            }
            permissionDefinitions.Add(permissionDefinition);
        }

        if (!permissionDefinitions.Any())
        {
            Logger.LogWarning($"No permission found in the permission definition manager for the event: {eventData.GetType().FullName}");
            return;
        }

        var permissionNames = permissionDefinitions
            .Where(p => p.MultiTenancySide.HasFlag(MultiTenancySides.Host))
            .Where(p => !p.Providers.Any() || p.Providers.Contains(RolePermissionValueProvider.ProviderName))
            .Select(p => p.Name)
            .ToArray();

        if (!permissionNames.Any())
        {
            Logger.LogWarning($"No permission found that can be added to the `admin` role for the event: {eventData.GetType().FullName}");
            return;
        }

        Logger.LogInformation($"Trying to seed dynamic permissions to `admin` role for the event: {eventData.GetType().FullName}");
        Logger.LogInformation($"Permissions: {permissionNames.JoinAsString(", ")}");

        await PermissionDataSeeder.SeedAsync(
            RolePermissionValueProvider.ProviderName,
            "admin",
            permissionNames,
            null
        );
    }
}
