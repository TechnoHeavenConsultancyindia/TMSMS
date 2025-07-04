using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class CountryCreateDtoBase
    {
        public string? LocationId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? CountryCode { get; set; }
        public string? CountrySubdivisionCode { get; set; }
        public string? IataAirportCode { get; set; }
        public string? IataAirportMetroCode { get; set; }
        public string? PolygonType { get; set; }
        public string? Categories { get; set; }
        public string? Tags { get; set; }
        public int StatusFlag { get; set; }
        public string? Descriptor { get; set; }
    }
}