using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantTagCreateDtoBase
    {
        [Required]
        [StringLength(RestaurantTagConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(RestaurantTagConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}