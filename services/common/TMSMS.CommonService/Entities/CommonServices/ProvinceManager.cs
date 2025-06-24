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
    public abstract class ProvinceManagerBase : DomainService
    {
        protected IProvinceRepository _provinceRepository;

        public ProvinceManagerBase(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public virtual async Task<Province> CreateAsync(
        string name, string categories, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? tags = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(categories, nameof(categories));

            var province = new Province(

             name, categories, statusFlag, locationId, fullName, descriptor, iataAirportCode, iataAirportMetroCode, countrySubdivisionCode, latitude, longitude, polygonType, countryCode, tags
             );

            return await _provinceRepository.InsertAsync(province);
        }

        public virtual async Task<Province> UpdateAsync(
            int id,
            string name, string categories, int statusFlag, string? locationId = null, string? fullName = null, string? descriptor = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? countrySubdivisionCode = null, string? latitude = null, string? longitude = null, string? polygonType = null, string? countryCode = null, string? tags = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(categories, nameof(categories));

            var province = await _provinceRepository.GetAsync(id);

            province.Name = name;
            province.Categories = categories;
            province.StatusFlag = statusFlag;
            province.LocationId = locationId;
            province.FullName = fullName;
            province.Descriptor = descriptor;
            province.IataAirportCode = iataAirportCode;
            province.IataAirportMetroCode = iataAirportMetroCode;
            province.CountrySubdivisionCode = countrySubdivisionCode;
            province.Latitude = latitude;
            province.Longitude = longitude;
            province.PolygonType = polygonType;
            province.CountryCode = countryCode;
            province.Tags = tags;

            province.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _provinceRepository.UpdateAsync(province);
        }

    }
}