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
    [ControllerName("RestaurantCuisine")]
    [Route("api/restaurant/restaurant-cuisines")]

    public class RestaurantCuisineController : RestaurantCuisineControllerBase, IRestaurantCuisinesAppService
    {
        public RestaurantCuisineController(IRestaurantCuisinesAppService restaurantCuisinesAppService) : base(restaurantCuisinesAppService)
        {
        }
    }
}