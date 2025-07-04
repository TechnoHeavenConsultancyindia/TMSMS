using TMSMS.CommonService;
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public SupplierType Type { get; set; }
        public string ContactName { get; set; } = null!;
        public string? ContactEmail { get; set; }
        public string? DialCode { get; set; }
        public string? ContactPhone { get; set; }
        public SupplierStatus SupplierStatus { get; set; }
        public bool Preffered { get; set; }
        public int CountryId { get; set; }
        public int SupplierServiceTypeId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}