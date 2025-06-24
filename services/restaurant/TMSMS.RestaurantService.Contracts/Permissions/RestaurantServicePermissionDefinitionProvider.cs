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

        var restaurantDietaryTypePermission = myGroup.AddPermission(RestaurantServicePermissions.RestaurantDietaryTypes.Default, L("Permission:RestaurantDietaryTypes"));
        restaurantDietaryTypePermission.AddChild(RestaurantServicePermissions.RestaurantDietaryTypes.Create, L("Permission:Create"));
        restaurantDietaryTypePermission.AddChild(RestaurantServicePermissions.RestaurantDietaryTypes.Edit, L("Permission:Edit"));
        restaurantDietaryTypePermission.AddChild(RestaurantServicePermissions.RestaurantDietaryTypes.Delete, L("Permission:Delete"));

        var restaurantCuisinePermission = myGroup.AddPermission(RestaurantServicePermissions.RestaurantCuisines.Default, L("Permission:RestaurantCuisines"));
        restaurantCuisinePermission.AddChild(RestaurantServicePermissions.RestaurantCuisines.Create, L("Permission:Create"));
        restaurantCuisinePermission.AddChild(RestaurantServicePermissions.RestaurantCuisines.Edit, L("Permission:Edit"));
        restaurantCuisinePermission.AddChild(RestaurantServicePermissions.RestaurantCuisines.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RestaurantServiceResource>(name);
    }
}