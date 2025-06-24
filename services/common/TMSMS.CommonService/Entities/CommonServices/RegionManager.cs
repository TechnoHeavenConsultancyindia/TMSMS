using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class RegionManagerBase : DomainService
    {
        protected IRegionRepository _regionRepository;

        public RegionManagerBase(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public virtual async Task<Region> CreateAsync(
        string name, string categories, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? tags = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(categories, nameof(categories));

            var region = new Region(

             name, categories, statusFlag, locationId, fullName, descriptor, iataAirportCode, iataAirportMetroCode, countrySubdivisionCode, latitude, longitude, polygonType, countryCode, tags
             );

            return await _regionRepository.InsertAsync(region);
        }

        public virtual async Task<Region> UpdateAsync(
            int id,
            string name, string categories, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? tags = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(categories, nameof(categories));

            var region = await _regionRepository.GetAsync(id);

            region.Name = name;
            region.Categories = categories;
            region.StatusFlag = statusFlag;
            region.LocationId = locationId;
            region.FullName = fullName;
            region.Descriptor = descriptor;
            region.IataAirportCode = iataAirportCode;
            region.IataAirportMetroCode = iataAirportMetroCode;
            region.CountrySubdivisionCode = countrySubdivisionCode;
            region.Latitude = latitude;
            region.Longitude = longitude;
            region.PolygonType = polygonType;
            region.CountryCode = countryCode;
            region.Tags = tags;

            region.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _regionRepository.UpdateAsync(region);
        }

    }
}