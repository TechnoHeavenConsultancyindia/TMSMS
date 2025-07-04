using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class WeekDayDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public string DayAbbreviation { get; set; } = null!;
        public bool IsWeekend { get; set; }
        public int DisplayOrder { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}