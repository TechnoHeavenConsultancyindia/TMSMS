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
    [ControllerName("RestaurantType")]
    [Route("api/restaurant/restaurant-types")]

    public class RestaurantTypeController : RestaurantTypeControllerBase, IRestaurantTypesAppService
    {
        public RestaurantTypeController(IRestaurantTypesAppService restaurantTypesAppService) : base(restaurantTypesAppService)
        {
        }
    }
}