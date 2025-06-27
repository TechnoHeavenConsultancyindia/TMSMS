using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantCuisineCreateDtoBase
    {
        [Required]
        [StringLength(RestaurantCuisineConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(RestaurantCuisineConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}