using TMSMS.CommonService;
using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class GetSupplierMastersInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public SupplierType? Type { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? DialCode { get; set; }
        public string? ContactPhone { get; set; }
        public SupplierStatus? SupplierStatus { get; set; }
        public bool? Preffered { get; set; }
        public int? CountryId { get; set; }
        public int? SupplierServiceTypeId { get; set; }

        public GetSupplierMastersInputBase()
        {

        }
    }
}