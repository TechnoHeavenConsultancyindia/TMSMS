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
    public abstract class CityManagerBase : DomainService
    {
        protected ICityRepository _cityRepository;

        public CityManagerBase(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public virtual async Task<City> CreateAsync(
        string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var city = new City(

             name, statusFlag, locationId, fullName, latitude, longitude, countryCode, countrySubdivisionCode, iataAirportCode, iataAirportMetroCode, polygonType, categories, tags, descriptor
             );

            return await _cityRepository.InsertAsync(city);
        }

        public virtual async Task<City> UpdateAsync(
            int id,
            string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var city = await _cityRepository.GetAsync(id);

            city.Name = name;
            city.StatusFlag = statusFlag;
            city.LocationId = locationId;
            city.FullName = fullName;
            city.Latitude = latitude;
            city.Longitude = longitude;
            city.CountryCode = countryCode;
            city.CountrySubdivisionCode = countrySubdivisionCode;
            city.IataAirportCode = iataAirportCode;
            city.IataAirportMetroCode = iataAirportMetroCode;
            city.PolygonType = polygonType;
            city.Categories = categories;
            city.Tags = tags;
            city.Descriptor = descriptor;

            city.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _cityRepository.UpdateAsync(city);
        }

    }
}