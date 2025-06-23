using System;
using TMSMS.RestaurantService.Shared;
using Volo.Abp.AutoMapper;
using TMSMS.RestaurantService.RestaurantServices;
using AutoMapper;

namespace TMSMS.RestaurantService.ObjectMapping;

public class RestaurantServiceApplicationAutoMapperProfile : Profile
{
    public RestaurantServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<RestaurantType, RestaurantTypeDto>();
        CreateMap<RestaurantType, RestaurantTypeExcelDto>();

        CreateMap<RestaurantTag, RestaurantTagDto>();
        CreateMap<RestaurantTag, RestaurantTagExcelDto>();

        CreateMap<RestaurantDietaryType, RestaurantDietaryTypeDto>();
        CreateMap<RestaurantDietaryType, RestaurantDietaryTypeExcelDto>();
    }
}