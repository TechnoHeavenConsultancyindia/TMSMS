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
        string name, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? categories = null, string? tags = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var city = new City(

             name, statusFlag, locationId, fullName, descriptor, iataAirportCode, iataAirportMetroCode, countrySubdivisionCode, latitude, longitude, polygonType, countryCode, categories, tags
             );

            return await _cityRepository.InsertAsync(city);
        }

        public virtual async Task<City> UpdateAsync(
            int id,
            string name, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? categories = null, string? tags = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var city = await _cityRepository.GetAsync(id);

            city.Name = name;
            city.StatusFlag = statusFlag;
            city.LocationId = locationId;
            city.FullName = fullName;
            city.Descriptor = descriptor;
            city.IataAirportCode = iataAirportCode;
            city.IataAirportMetroCode = iataAirportMetroCode;
            city.CountrySubdivisionCode = countrySubdivisionCode;
            city.Latitude = latitude;
            city.Longitude = longitude;
            city.PolygonType = polygonType;
            city.CountryCode = countryCode;
            city.Categories = categories;
            city.Tags = tags;

            city.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _cityRepository.UpdateAsync(city);
        }

    }
}