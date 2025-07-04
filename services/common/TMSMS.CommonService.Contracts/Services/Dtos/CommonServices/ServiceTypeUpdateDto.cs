using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class ServiceTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [StringLength(ServiceTypeConsts.NameMaxLength)]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}