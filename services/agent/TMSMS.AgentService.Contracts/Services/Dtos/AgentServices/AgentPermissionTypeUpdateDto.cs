using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentPermissionTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(AgentPermissionTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(AgentPermissionTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}