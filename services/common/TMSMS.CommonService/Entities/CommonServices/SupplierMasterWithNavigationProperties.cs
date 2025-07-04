using TMSMS.CommonService.CommonServices;
using TMSMS.CommonService.CommonServices;

using System;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterWithNavigationPropertiesBase
    {
        public SupplierMaster SupplierMaster { get; set; } = null!;

        public Country Country { get; set; } = null!;
        public SupplierServiceType SupplierServiceType { get; set; } = null!;
        

        
    }
}