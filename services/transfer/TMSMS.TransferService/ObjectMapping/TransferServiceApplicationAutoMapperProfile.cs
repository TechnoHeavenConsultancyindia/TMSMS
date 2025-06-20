using System;
using TMSMS.TransferService.Shared;
using Volo.Abp.AutoMapper;
using TMSMS.TransferService.TransferServices;
using AutoMapper;

namespace TMSMS.TransferService.ObjectMapping;

public class TransferServiceApplicationAutoMapperProfile : Profile
{
    public TransferServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<TransferType, TransferTypeDto>();
        CreateMap<TransferType, TransferTypeExcelDto>();
    }
}