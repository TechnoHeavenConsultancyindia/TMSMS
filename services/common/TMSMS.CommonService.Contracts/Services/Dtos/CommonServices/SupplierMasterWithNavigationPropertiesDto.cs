using TMSMS.CommonService.CommonServices;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterWithNavigationPropertiesDtoBase
    {
        public SupplierMasterDto SupplierMaster { get; set; } = null!;

        public CountryDto Country { get; set; } = null!;
        public SupplierServiceTypeDto SupplierServiceType { get; set; } = null!;

    }
}