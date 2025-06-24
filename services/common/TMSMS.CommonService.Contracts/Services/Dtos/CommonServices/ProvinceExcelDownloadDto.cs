using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class ProvinceExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? LocationId { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string? Descriptor { get; set; }
        public string? IataAirportCode { get; set; }
        public string? IataAirportMetroCode { get; set; }
        public string? CountrySubdivisionCode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? PolygonType { get; set; }
        public string? CountryCode { get; set; }
        public string? Categories { get; set; }
        public string? Tags { get; set; }
        public int? StatusFlagMin { get; set; }
        public int? StatusFlagMax { get; set; }

        public ProvinceExcelDownloadDtoBase()
        {

        }
    }
}