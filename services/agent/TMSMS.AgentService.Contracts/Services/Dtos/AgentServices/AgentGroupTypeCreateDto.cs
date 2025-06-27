using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentGroupTypeCreateDtoBase
    {
        [Required]
        [StringLength(AgentGroupTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(AgentGroupTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}