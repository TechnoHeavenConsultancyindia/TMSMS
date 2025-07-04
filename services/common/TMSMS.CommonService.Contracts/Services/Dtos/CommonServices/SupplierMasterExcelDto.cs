using TMSMS.CommonService;
using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterExcelDtoBase
    {
        public string Name { get; set; } = null!;
        public SupplierType Type { get; set; }
        public string ContactName { get; set; } = null!;
        public string? ContactEmail { get; set; }
        public string? DialCode { get; set; }
        public string? ContactPhone { get; set; }
        public SupplierStatus SupplierStatus { get; set; }
        public bool Preffered { get; set; }
    }
}