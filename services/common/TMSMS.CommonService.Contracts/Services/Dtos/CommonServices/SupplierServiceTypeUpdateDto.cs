using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierServiceTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(SupplierServiceTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(SupplierServiceTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}