using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentPermissionTypeCreateDtoBase
    {
        [Required]
        [StringLength(AgentPermissionTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(AgentPermissionTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}