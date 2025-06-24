using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class GetRestaurantCuisinesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public GetRestaurantCuisinesInputBase()
        {

        }
    }
}