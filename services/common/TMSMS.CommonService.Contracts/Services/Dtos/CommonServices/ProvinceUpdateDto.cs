using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class ProvinceUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? LocationId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Descriptor { get; set; }
        public string? IataAirportCode { get; set; }
        public string? IataAirportMetroCode { get; set; }
        public string? CountrySubdivisionCode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? PolygonType { get; set; }
        public string? CountryCode { get; set; }
        [Required]
        public string Categories { get; set; } = null!;
        public string? Tags { get; set; }
        public int StatusFlag { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}