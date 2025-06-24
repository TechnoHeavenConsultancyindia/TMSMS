using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaDiscountCategoryCreateDtoBase
    {
        [Required]
        [StringLength(VisaDiscountCategoryConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(VisaDiscountCategoryConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}