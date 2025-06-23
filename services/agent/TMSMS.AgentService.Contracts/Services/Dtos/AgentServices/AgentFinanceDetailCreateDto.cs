using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentFinanceDetailCreateDtoBase
    {
        public decimal CreditLimit { get; set; }
        [StringLength(AgentFinanceDetailConsts.CreditLimitCurrencyMaxLength)]
        public string? CreditLimitCurrency { get; set; }
        [StringLength(AgentFinanceDetailConsts.DisplayCurrencyMaxLength)]
        public string? DisplayCurrency { get; set; }
        public decimal OutstandingBalance { get; set; }
        public decimal ConvertedBalance { get; set; }
        public decimal LastConversionRate { get; set; }
    }
}