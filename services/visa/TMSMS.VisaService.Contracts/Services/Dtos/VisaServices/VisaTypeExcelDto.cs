using System;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTypeExcelDtoBase
    {
        public string Name { get; set; } = null!;
        public string? SubCategory { get; set; }
    }
}