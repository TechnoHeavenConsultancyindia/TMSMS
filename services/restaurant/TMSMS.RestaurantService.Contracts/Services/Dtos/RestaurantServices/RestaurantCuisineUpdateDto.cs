using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantCuisineUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(RestaurantCuisineConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(RestaurantCuisineConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}