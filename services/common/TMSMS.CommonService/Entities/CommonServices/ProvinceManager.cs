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
        string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var province = new Province(

             name, statusFlag, locationId, fullName, latitude, longitude, countryCode, countrySubdivisionCode, iataAirportCode, iataAirportMetroCode, polygonType, categories, tags, descriptor
             );

            return await _provinceRepository.InsertAsync(province);
        }

        public virtual async Task<Province> UpdateAsync(
            int id,
            string name, int statusFlag, string? locationId = null, string? fullName = null, string? latitude = null, string? longitude = null, string? countryCode = null, string? countrySubdivisionCode = null, string? iataAirportCode = null, string? iataAirportMetroCode = null, string? polygonType = null, string? categories = null, string? tags = null, string? descriptor = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var province = await _provinceRepository.GetAsync(id);

            province.Name = name;
            province.StatusFlag = statusFlag;
            province.LocationId = locationId;
            province.FullName = fullName;
            province.Latitude = latitude;
            province.Longitude = longitude;
            province.CountryCode = countryCode;
            province.CountrySubdivisionCode = countrySubdivisionCode;
            province.IataAirportCode = iataAirportCode;
            province.IataAirportMetroCode = iataAirportMetroCode;
            province.PolygonType = polygonType;
            province.Categories = categories;
            province.Tags = tags;
            province.Descriptor = descriptor;

            province.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _provinceRepository.UpdateAsync(province);
        }

    }
}