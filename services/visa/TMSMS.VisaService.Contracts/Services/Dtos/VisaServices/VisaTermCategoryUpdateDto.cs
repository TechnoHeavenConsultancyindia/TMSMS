using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTermCategoryUpdateDtoBase : IHasConcurrencyStamp
    {
        [StringLength(VisaTermCategoryConsts.NameMaxLength)]
        public string? Name { get; set; }
        [StringLength(VisaTermCategoryConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}