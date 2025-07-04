using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class WeekDayExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? DayAbbreviation { get; set; }
        public bool? IsWeekend { get; set; }
        public int? DisplayOrderMin { get; set; }
        public int? DisplayOrderMax { get; set; }

        public WeekDayExcelDownloadDtoBase()
        {

        }
    }
}