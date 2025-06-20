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
    public abstract class CountryManagerBase : DomainService
    {
        protected ICountryRepository _countryRepository;

        public CountryManagerBase(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public virtual async Task<Country> CreateAsync(
        string name, string categories, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? tags = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(categories, nameof(categories));

            var country = new Country(

             name, categories, statusFlag, locationId, fullName, descriptor, iataAirportCode, iataAirportMetroCode, countrySubdivisionCode, latitude, longitude, polygonType, countryCode, tags
             );

            return await _countryRepository.InsertAsync(country);
        }

        public virtual async Task<Country> UpdateAsync(
            int id,
            string name, string categories, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? tags = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(categories, nameof(categories));

            var country = await _countryRepository.GetAsync(id);

            country.Name = name;
            country.Categories = categories;
            country.StatusFlag = statusFlag;
            country.LocationId = locationId;
            country.FullName = fullName;
            country.Descriptor = descriptor;
            country.IataAirportCode = iataAirportCode;
            country.IataAirportMetroCode = iataAirportMetroCode;
            country.CountrySubdivisionCode = countrySubdivisionCode;
            country.Latitude = latitude;
            country.Longitude = longitude;
            country.PolygonType = polygonType;
            country.CountryCode = countryCode;
            country.Tags = tags;

            country.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _countryRepository.UpdateAsync(country);
        }

    }
}