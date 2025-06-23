using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(VisaTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(VisaTypeConsts.SubCategoryMaxLength)]
        public string? SubCategory { get; set; }
        public string? VisaPurpose { get; set; }
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}