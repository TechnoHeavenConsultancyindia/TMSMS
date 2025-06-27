using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentFinanceDetailUpdateDtoBase : IHasConcurrencyStamp
    {
        public decimal CreditLimit { get; set; }
        [StringLength(AgentFinanceDetailConsts.CreditLimitCurrencyMaxLength)]
        public string? CreditLimitCurrency { get; set; }
        [StringLength(AgentFinanceDetailConsts.DisplayCurrencyMaxLength)]
        public string? DisplayCurrency { get; set; }
        public decimal OutstandingBalance { get; set; }
        public decimal ConvertedBalance { get; set; }
        public decimal LastConversionRate { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}