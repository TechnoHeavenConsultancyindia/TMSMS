using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierServiceTypeDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}