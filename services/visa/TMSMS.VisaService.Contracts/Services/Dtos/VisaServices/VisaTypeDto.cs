using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTypeDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public string? SubCategory { get; set; }
        public string? VisaPurpose { get; set; }
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}