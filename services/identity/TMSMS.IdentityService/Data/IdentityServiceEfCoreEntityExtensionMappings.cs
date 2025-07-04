﻿using Volo.Abp.Threading;

namespace TMSMS.IdentityService.Data;

public static class IdentityServiceEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public static void Configure()
    {
        IdentityServiceModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
                /* You can configure extra properties for the
                 * entities defined in the modules used by your application.
                 *
                 * This class can be used to map these extra properties to table fields in the database.
                 *
                 * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
                 * USE IdentityServiceModuleExtensionConfigurator CLASS
                 * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
                 *
                 * Example: Map a property to a table field:
                    ObjectExtensionManager.Instance
                        .MapEfCoreProperty<IdentityUser, string>(
                            "SocialSecurityNumber",
                            (entityBuilder, propertyBuilder) =>
                            {
                                propertyBuilder.HasMaxLength(128);
                            }
                        );
                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
                 */
        });
    }
}
