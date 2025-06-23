using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantDietaryTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(RestaurantDietaryTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(RestaurantDietaryTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}