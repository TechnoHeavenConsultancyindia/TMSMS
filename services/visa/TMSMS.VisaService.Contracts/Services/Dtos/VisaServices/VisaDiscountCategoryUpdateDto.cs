using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaDiscountCategoryUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(VisaDiscountCategoryConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(VisaDiscountCategoryConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}