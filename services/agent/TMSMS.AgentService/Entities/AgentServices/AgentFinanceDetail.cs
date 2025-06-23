using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentFinanceDetailBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual decimal CreditLimit { get; set; }

        [CanBeNull]
        public virtual string? CreditLimitCurrency { get; set; }

        [CanBeNull]
        public virtual string? DisplayCurrency { get; set; }

        public virtual decimal OutstandingBalance { get; set; }

        public virtual decimal ConvertedBalance { get; set; }

        public virtual decimal LastConversionRate { get; set; }

        protected AgentFinanceDetailBase()
        {

        }

        public AgentFinanceDetailBase(decimal creditLimit, decimal outstandingBalance, decimal convertedBalance, decimal lastConversionRate, string? creditLimitCurrency = null, string? displayCurrency = null)
        {

            Check.Length(creditLimitCurrency, nameof(creditLimitCurrency), AgentFinanceDetailConsts.CreditLimitCurrencyMaxLength, 0);
            Check.Length(displayCurrency, nameof(displayCurrency), AgentFinanceDetailConsts.DisplayCurrencyMaxLength, 0);
            CreditLimit = creditLimit;
            OutstandingBalance = outstandingBalance;
            ConvertedBalance = convertedBalance;
            LastConversionRate = lastConversionRate;
            CreditLimitCurrency = creditLimitCurrency;
            DisplayCurrency = displayCurrency;
        }

    }
}