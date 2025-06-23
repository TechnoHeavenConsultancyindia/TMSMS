using TMSMS.RestaurantService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TMSMS.RestaurantService.Permissions;

public class RestaurantServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(RestaurantServicePermissions.GroupName);

        var restaurantTypePermission = myGroup.AddPermission(RestaurantServicePermissions.RestaurantTypes.Default, L("Permission:RestaurantTypes"));
        restaurantTypePermission.AddChild(RestaurantServicePermissions.RestaurantTypes.Create, L("Permission:Create"));
        restaurantTypePermission.AddChild(RestaurantServicePermissions.RestaurantTypes.Edit, L("Permission:Edit"));
        restaurantTypePermission.AddChild(RestaurantServicePermissions.RestaurantTypes.Delete, L("Permission:Delete"));

        var restaurantTagPermission = myGroup.AddPermission(RestaurantServicePermissions.RestaurantTags.Default, L("Permission:RestaurantTags"));
        restaurantTagPermission.AddChild(RestaurantServicePermissions.RestaurantTags.Create, L("Permission:Create"));
        restaurantTagPermission.AddChild(RestaurantServicePermissions.RestaurantTags.Edit, L("Permission:Edit"));
        restaurantTagPermission.AddChild(RestaurantServicePermissions.RestaurantTags.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RestaurantServiceResource>(name);
    }
}