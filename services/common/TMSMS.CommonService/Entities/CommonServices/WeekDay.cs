using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class WeekDayBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string DayAbbreviation { get; set; }

        public virtual bool IsWeekend { get; set; }

        public virtual int DisplayOrder { get; set; }

        protected WeekDayBase()
        {

        }

        public WeekDayBase(string name, string dayAbbreviation, bool isWeekend, int displayOrder)
        {

            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), WeekDayConsts.NameMaxLength, 0);
            Check.NotNull(dayAbbreviation, nameof(dayAbbreviation));
            Check.Length(dayAbbreviation, nameof(dayAbbreviation), WeekDayConsts.DayAbbreviationMaxLength, 0);
            Name = name;
            DayAbbreviation = dayAbbreviation;
            IsWeekend = isWeekend;
            DisplayOrder = displayOrder;
        }

    }
}