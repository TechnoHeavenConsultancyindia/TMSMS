using TMSMS.CommonService.CommonServices;
using TMSMS.CommonService.CommonServices;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeMasterWithNavigationPropertiesDtoBase
    {
        public PromoCodeMasterDto PromoCodeMaster { get; set; } = null!;

        public List<CountryDto> Countries { get; set; } = new List<CountryDto>();
        public List<CityDto> Cities { get; set; } = new List<CityDto>();

    }
}