using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? DialCode { get; set; }
        public string? ContactPhone { get; set; }
        public int? SupplierStatusMin { get; set; }
        public int? SupplierStatusMax { get; set; }
        public bool? Preffered { get; set; }
        public int? CountryId { get; set; }
        public int? SupplierServiceTypeId { get; set; }

        public SupplierMasterExcelDownloadDtoBase()
        {

        }
    }
}