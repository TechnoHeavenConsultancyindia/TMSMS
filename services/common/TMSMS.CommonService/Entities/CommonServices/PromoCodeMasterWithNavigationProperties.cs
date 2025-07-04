using TMSMS.CommonService.CommonServices;
using TMSMS.CommonService.CommonServices;

using System;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeMasterWithNavigationPropertiesBase
    {
        public PromoCodeMaster PromoCodeMaster { get; set; } = null!;

        

        public List<Country> Countries { get; set; } = null!;
        public List<City> Cities { get; set; } = null!;
        
    }
}