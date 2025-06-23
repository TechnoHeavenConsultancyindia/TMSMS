using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentVoucherTypeCreateDtoBase
    {
        [Required]
        [StringLength(AgentVoucherTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(AgentVoucherTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}