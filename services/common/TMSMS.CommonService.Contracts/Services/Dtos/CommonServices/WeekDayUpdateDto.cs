using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class WeekDayUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(WeekDayConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(WeekDayConsts.DayAbbreviationMaxLength)]
        public string DayAbbreviation { get; set; } = null!;
        public bool IsWeekend { get; set; }
        public int DisplayOrder { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}