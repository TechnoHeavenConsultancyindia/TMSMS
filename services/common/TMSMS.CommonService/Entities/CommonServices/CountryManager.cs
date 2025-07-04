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
        string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var country = new Country(

             name, statusFlag, locationId, fullName, latitude, longitude, countryCode, countrySubdivisionCode, iataAirportCode, iataAirportMetroCode, polygonType, categories, tags, descriptor
             );

            return await _countryRepository.InsertAsync(country);
        }

        public virtual async Task<Country> UpdateAsync(
            int id,
            string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var country = await _countryRepository.GetAsync(id);

            country.Name = name;
            country.StatusFlag = statusFlag;
            country.LocationId = locationId;
            country.FullName = fullName;
            country.Latitude = latitude;
            country.Longitude = longitude;
            country.CountryCode = countryCode;
            country.CountrySubdivisionCode = countrySubdivisionCode;
            country.IataAirportCode = iataAirportCode;
            country.IataAirportMetroCode = iataAirportMetroCode;
            country.PolygonType = polygonType;
            country.Categories = categories;
            country.Tags = tags;
            country.Descriptor = descriptor;

            country.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _countryRepository.UpdateAsync(country);
        }

    }
}