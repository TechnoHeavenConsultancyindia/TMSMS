using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentFinanceDetailExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public decimal? CreditLimitMin { get; set; }
        public decimal? CreditLimitMax { get; set; }
        public string? CreditLimitCurrency { get; set; }
        public string? DisplayCurrency { get; set; }
        public decimal? OutstandingBalanceMin { get; set; }
        public decimal? OutstandingBalanceMax { get; set; }
        public decimal? ConvertedBalanceMin { get; set; }
        public decimal? ConvertedBalanceMax { get; set; }
        public decimal? LastConversionRateMin { get; set; }
        public decimal? LastConversionRateMax { get; set; }

        public AgentFinanceDetailExcelDownloadDtoBase()
        {

        }
    }
}