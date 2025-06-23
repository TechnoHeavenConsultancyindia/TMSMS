using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTypeCreateDtoBase
    {
        [Required]
        [StringLength(VisaTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(VisaTypeConsts.SubCategoryMaxLength)]
        public string? SubCategory { get; set; }
        public string? VisaPurpose { get; set; }
        public string? Description { get; set; }
    }
}