using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class ServiceTypeCreateDtoBase
    {
        [StringLength(ServiceTypeConsts.NameMaxLength)]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}