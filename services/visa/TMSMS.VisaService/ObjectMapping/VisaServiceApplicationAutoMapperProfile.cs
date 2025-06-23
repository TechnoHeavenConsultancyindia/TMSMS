using System;
using TMSMS.VisaService.Shared;
using Volo.Abp.AutoMapper;
using TMSMS.VisaService.VisaServices;
using AutoMapper;

namespace TMSMS.VisaService.ObjectMapping;

public class VisaServiceApplicationAutoMapperProfile : Profile
{
    public VisaServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<VisaTermCategory, VisaTermCategoryDto>();
        CreateMap<VisaTermCategory, VisaTermCategoryExcelDto>();

        CreateMap<VisaType, VisaTypeDto>();
        CreateMap<VisaType, VisaTypeExcelDto>();
    }
}