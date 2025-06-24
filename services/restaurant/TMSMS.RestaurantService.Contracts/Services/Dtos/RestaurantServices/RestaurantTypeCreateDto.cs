using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantTypeCreateDtoBase
    {
        [Required]
        [StringLength(RestaurantTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(RestaurantTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}