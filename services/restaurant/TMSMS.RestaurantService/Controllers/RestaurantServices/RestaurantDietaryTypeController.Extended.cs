using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.RestaurantService.RestaurantServices;

namespace TMSMS.RestaurantService.RestaurantServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("RestaurantDietaryType")]
    [Route("api/restaurant/restaurant-dietary-types")]

    public class RestaurantDietaryTypeController : RestaurantDietaryTypeControllerBase, IRestaurantDietaryTypesAppService
    {
        public RestaurantDietaryTypeController(IRestaurantDietaryTypesAppService restaurantDietaryTypesAppService) : base(restaurantDietaryTypesAppService)
        {
        }
    }
}