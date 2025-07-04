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
    }
}