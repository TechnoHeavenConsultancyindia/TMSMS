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
        string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var region = new Region(

             name, statusFlag, locationId, fullName, latitude, longitude, countryCode, countrySubdivisionCode, iataAirportCode, iataAirportMetroCode, polygonType, categories, tags, descriptor
             );

            return await _regionRepository.InsertAsync(region);
        }

        public virtual async Task<Region> UpdateAsync(
            int id,
            string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var region = await _regionRepository.GetAsync(id);

            region.Name = name;
            region.StatusFlag = statusFlag;
            region.LocationId = locationId;
            region.FullName = fullName;
            region.Latitude = latitude;
            region.Longitude = longitude;
            region.CountryCode = countryCode;
            region.CountrySubdivisionCode = countrySubdivisionCode;
            region.IataAirportCode = iataAirportCode;
            region.IataAirportMetroCode = iataAirportMetroCode;
            region.PolygonType = polygonType;
            region.Categories = categories;
            region.Tags = tags;
            region.Descriptor = descriptor;

            region.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _regionRepository.UpdateAsync(region);
        }

    }
}