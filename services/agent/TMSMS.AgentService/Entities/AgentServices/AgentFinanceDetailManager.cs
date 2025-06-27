using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentFinanceDetailManagerBase : DomainService
    {
        protected IAgentFinanceDetailRepository _agentFinanceDetailRepository;

        public AgentFinanceDetailManagerBase(IAgentFinanceDetailRepository agentFinanceDetailRepository)
        {
            _agentFinanceDetailRepository = agentFinanceDetailRepository;
        }

        public virtual async Task<AgentFinanceDetail> CreateAsync(
        decimal creditLimit, decimal outstandingBalance, decimal convertedBalance, decimal lastConversionRate, string? creditLimitCurrency = null, string? displayCurrency = null)
        {
            Check.Length(creditLimitCurrency, nameof(creditLimitCurrency), AgentFinanceDetailConsts.CreditLimitCurrencyMaxLength);
            Check.Length(displayCurrency, nameof(displayCurrency), AgentFinanceDetailConsts.DisplayCurrencyMaxLength);

            var agentFinanceDetail = new AgentFinanceDetail(

             creditLimit, outstandingBalance, convertedBalance, lastConversionRate, creditLimitCurrency, displayCurrency
             );

            return await _agentFinanceDetailRepository.InsertAsync(agentFinanceDetail);
        }

        public virtual async Task<AgentFinanceDetail> UpdateAsync(
            int id,
            decimal creditLimit, decimal outstandingBalance, decimal convertedBalance, decimal lastConversionRate, string? creditLimitCurrency = null, string? displayCurrency = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.Length(creditLimitCurrency, nameof(creditLimitCurrency), AgentFinanceDetailConsts.CreditLimitCurrencyMaxLength);
            Check.Length(displayCurrency, nameof(displayCurrency), AgentFinanceDetailConsts.DisplayCurrencyMaxLength);

            var agentFinanceDetail = await _agentFinanceDetailRepository.GetAsync(id);

            agentFinanceDetail.CreditLimit = creditLimit;
            agentFinanceDetail.OutstandingBalance = outstandingBalance;
            agentFinanceDetail.ConvertedBalance = convertedBalance;
            agentFinanceDetail.LastConversionRate = lastConversionRate;
            agentFinanceDetail.CreditLimitCurrency = creditLimitCurrency;
            agentFinanceDetail.DisplayCurrency = displayCurrency;

            agentFinanceDetail.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _agentFinanceDetailRepository.UpdateAsync(agentFinanceDetail);
        }

    }
}