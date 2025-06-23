using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentGroupTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(AgentGroupTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(AgentGroupTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}