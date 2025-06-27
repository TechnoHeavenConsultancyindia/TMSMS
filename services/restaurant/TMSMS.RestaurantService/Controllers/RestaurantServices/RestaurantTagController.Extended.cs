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
    [ControllerName("RestaurantTag")]
    [Route("api/restaurant/restaurant-tags")]

    public class RestaurantTagController : RestaurantTagControllerBase, IRestaurantTagsAppService
    {
        public RestaurantTagController(IRestaurantTagsAppService restaurantTagsAppService) : base(restaurantTagsAppService)
        {
        }
    }
}