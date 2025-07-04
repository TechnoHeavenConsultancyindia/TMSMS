using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class WeekDayCreateDtoBase
    {
        [Required]
        [StringLength(WeekDayConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(WeekDayConsts.DayAbbreviationMaxLength)]
        public string DayAbbreviation { get; set; } = null!;
        public bool IsWeekend { get; set; }
        public int DisplayOrder { get; set; }
    }
}