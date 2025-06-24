using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class RegionExcelDtoBase
    {
        public string? LocationId { get; set; }
        public string Name { get; set; } = null!;
        public string? FullName { get; set; }
        public string? IataAirportCode { get; set; }
        public string? IataAirportMetroCode { get; set; }
        public string? CountrySubdivisionCode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? PolygonType { get; set; }
        public string Categories { get; set; } = null!;
        public string? CountryCode { get; set; }
        public string? Tags { get; set; }
        public int StatusFlag { get; set; }
    }
}