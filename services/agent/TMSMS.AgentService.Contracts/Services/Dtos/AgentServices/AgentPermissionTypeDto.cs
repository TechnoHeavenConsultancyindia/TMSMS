using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentPermissionTypeDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}