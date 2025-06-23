using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantDietaryTypeCreateDtoBase
    {
        [Required]
        [StringLength(RestaurantDietaryTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(RestaurantDietaryTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}