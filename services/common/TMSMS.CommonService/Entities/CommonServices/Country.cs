using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class CountryBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? LocationId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? FullName { get; set; }

        [CanBeNull]
        public virtual string? Latitude { get; set; }

        [CanBeNull]
        public virtual string? Longitude { get; set; }

        [CanBeNull]
        public virtual string? CountryCode { get; set; }

        [CanBeNull]
        public virtual string? CountrySubdivisionCode { get; set; }

        [CanBeNull]
        public virtual string? IataAirportCode { get; set; }

        [CanBeNull]
        public virtual string? IataAirportMetroCode { get; set; }

        [CanBeNull]
        public virtual string? PolygonType { get; set; }

        [CanBeNull]
        public virtual string? Categories { get; set; }

        [CanBeNull]
        public virtual string? Tags { get; set; }

        public virtual int StatusFlag { get; set; }

        [CanBeNull]
        public virtual string? Descriptor { get; set; }

        protected CountryBase()
        {

        }

        public CountryBase(string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null)
        {

            Check.NotNull(name, nameof(name));
            Name = name;
            StatusFlag = statusFlag;
            LocationId = locationId;
            FullName = fullName;
            Latitude = latitude;
            Longitude = longitude;
            CountryCode = countryCode;
            CountrySubdivisionCode = countrySubdivisionCode;
            IataAirportCode = iataAirportCode;
            IataAirportMetroCode = iataAirportMetroCode;
            PolygonType = polygonType;
            Categories = categories;
            Tags = tags;
            Descriptor = descriptor;
        }

    }
}