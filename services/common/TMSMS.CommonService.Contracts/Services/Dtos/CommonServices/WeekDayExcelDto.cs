using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class WeekDayExcelDtoBase
    {
        public string Name { get; set; } = null!;
        public string DayAbbreviation { get; set; } = null!;
        public bool IsWeekend { get; set; }
        public int DisplayOrder { get; set; }
    }
}