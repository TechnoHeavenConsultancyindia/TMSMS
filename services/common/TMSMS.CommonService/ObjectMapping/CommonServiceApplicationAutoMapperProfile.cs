using System;
using TMSMS.CommonService.Shared;
using Volo.Abp.AutoMapper;
using TMSMS.CommonService.CommonServices;
using AutoMapper;

namespace TMSMS.CommonService.ObjectMapping;

public class CommonServiceApplicationAutoMapperProfile : Profile
{
    public CommonServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<Country, CountryDto>();
        CreateMap<Country, CountryExcelDto>();

        CreateMap<City, CityDto>();
        CreateMap<City, CityExcelDto>();

        CreateMap<Province, ProvinceDto>();
        CreateMap<Province, ProvinceExcelDto>();

        CreateMap<Region, RegionDto>();
        CreateMap<Region, RegionExcelDto>();

        CreateMap<WeekDay, WeekDayDto>();
        CreateMap<WeekDay, WeekDayExcelDto>();

        CreateMap<PromoCodeMaster, PromoCodeMasterDto>();
        CreateMap<PromoCodeMaster, PromoCodeMasterExcelDto>();
        CreateMap<PromoCodeMasterWithNavigationProperties, PromoCodeMasterWithNavigationPropertiesDto>();
        CreateMap<Country, LookupDto<int>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
        CreateMap<City, LookupDto<int>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

        CreateMap<PromoCodeUsageTracking, PromoCodeUsageTrackingDto>();
        CreateMap<PromoCodeUsageTracking, PromoCodeUsageTrackingExcelDto>();
        CreateMap<PromoCodeUsageTrackingWithNavigationProperties, PromoCodeUsageTrackingWithNavigationPropertiesDto>();
        CreateMap<PromoCodeMaster, LookupDto<int>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

        CreateMap<SupplierServiceType, SupplierServiceTypeDto>();
        CreateMap<SupplierServiceType, SupplierServiceTypeExcelDto>();

        CreateMap<SupplierMaster, SupplierMasterDto>();
        CreateMap<SupplierMaster, SupplierMasterExcelDto>();
        CreateMap<SupplierMasterWithNavigationProperties, SupplierMasterWithNavigationPropertiesDto>();
        CreateMap<SupplierServiceType, LookupDto<int>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
    }
}