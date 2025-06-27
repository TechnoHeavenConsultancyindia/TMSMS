using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentFinanceDetailDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public decimal CreditLimit { get; set; }
        public string? CreditLimitCurrency { get; set; }
        public string? DisplayCurrency { get; set; }
        public decimal OutstandingBalance { get; set; }
        public decimal ConvertedBalance { get; set; }
        public decimal LastConversionRate { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}