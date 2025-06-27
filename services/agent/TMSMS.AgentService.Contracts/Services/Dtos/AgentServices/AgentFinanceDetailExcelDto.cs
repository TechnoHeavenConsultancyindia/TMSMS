using System;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentFinanceDetailExcelDtoBase
    {
        public decimal CreditLimit { get; set; }
        public string? CreditLimitCurrency { get; set; }
        public string? DisplayCurrency { get; set; }
        public decimal OutstandingBalance { get; set; }
        public decimal ConvertedBalance { get; set; }
        public decimal LastConversionRate { get; set; }
    }
}