using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierServiceTypeCreateDtoBase
    {
        [Required]
        [StringLength(SupplierServiceTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(SupplierServiceTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}