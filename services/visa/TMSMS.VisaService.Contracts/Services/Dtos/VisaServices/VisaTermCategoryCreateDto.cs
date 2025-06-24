using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTermCategoryCreateDtoBase
    {
        [StringLength(VisaTermCategoryConsts.NameMaxLength)]
        public string? Name { get; set; }
        [StringLength(VisaTermCategoryConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}