using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentVoucherTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(AgentVoucherTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(AgentVoucherTypeConsts.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}