using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class WeekDayManagerBase : DomainService
    {
        protected IWeekDayRepository _weekDayRepository;

        public WeekDayManagerBase(IWeekDayRepository weekDayRepository)
        {
            _weekDayRepository = weekDayRepository;
        }

        public virtual async Task<WeekDay> CreateAsync(
        string name, string dayAbbreviation, bool isWeekend, int displayOrder)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), WeekDayConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(dayAbbreviation, nameof(dayAbbreviation));
            Check.Length(dayAbbreviation, nameof(dayAbbreviation), WeekDayConsts.DayAbbreviationMaxLength);

            var weekDay = new WeekDay(

             name, dayAbbreviation, isWeekend, displayOrder
             );

            return await _weekDayRepository.InsertAsync(weekDay);
        }

        public virtual async Task<WeekDay> UpdateAsync(
            int id,
            string name, string dayAbbreviation, bool isWeekend, int displayOrder, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), WeekDayConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(dayAbbreviation, nameof(dayAbbreviation));
            Check.Length(dayAbbreviation, nameof(dayAbbreviation), WeekDayConsts.DayAbbreviationMaxLength);

            var weekDay = await _weekDayRepository.GetAsync(id);

            weekDay.Name = name;
            weekDay.DayAbbreviation = dayAbbreviation;
            weekDay.IsWeekend = isWeekend;
            weekDay.DisplayOrder = displayOrder;

            weekDay.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _weekDayRepository.UpdateAsync(weekDay);
        }

    }
}