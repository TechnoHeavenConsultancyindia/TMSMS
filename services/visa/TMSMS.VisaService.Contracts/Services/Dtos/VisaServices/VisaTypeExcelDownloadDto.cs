using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTypeExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? SubCategory { get; set; }
        public string? VisaPurpose { get; set; }
        public string? Description { get; set; }

        public VisaTypeExcelDownloadDtoBase()
        {

        }
    }
}