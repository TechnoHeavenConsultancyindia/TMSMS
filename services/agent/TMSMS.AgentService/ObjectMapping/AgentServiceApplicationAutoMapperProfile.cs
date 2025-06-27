using System;
using TMSMS.AgentService.Shared;
using Volo.Abp.AutoMapper;
using TMSMS.AgentService.AgentServices;
using AutoMapper;

namespace TMSMS.AgentService.ObjectMapping;

public class AgentServiceApplicationAutoMapperProfile : Profile
{
    public AgentServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<AgentGroupType, AgentGroupTypeDto>();
        CreateMap<AgentGroupType, AgentGroupTypeExcelDto>();

        CreateMap<AgentPermissionType, AgentPermissionTypeDto>();
        CreateMap<AgentPermissionType, AgentPermissionTypeExcelDto>();

        CreateMap<AgentVoucherType, AgentVoucherTypeDto>();
        CreateMap<AgentVoucherType, AgentVoucherTypeExcelDto>();

        CreateMap<AgentFinanceDetail, AgentFinanceDetailDto>();
        CreateMap<AgentFinanceDetail, AgentFinanceDetailExcelDto>();
    }
}