using TMSMS.CommonService;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterCreateDtoBase
    {
        [Required]
        [StringLength(SupplierMasterConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        public SupplierType Type { get; set; } = ((SupplierType[])Enum.GetValues(typeof(SupplierType)))[0];
        [Required]
        [StringLength(SupplierMasterConsts.ContactNameMaxLength)]
        public string ContactName { get; set; } = null!;
        [EmailAddress]
        [StringLength(SupplierMasterConsts.ContactEmailMaxLength)]
        public string? ContactEmail { get; set; }
        [StringLength(SupplierMasterConsts.DialCodeMaxLength)]
        public string? DialCode { get; set; }
        [StringLength(SupplierMasterConsts.ContactPhoneMaxLength)]
        public string? ContactPhone { get; set; }
        public SupplierStatus SupplierStatus { get; set; } = ((SupplierStatus[])Enum.GetValues(typeof(SupplierStatus)))[0];
        public bool Preffered { get; set; }
        public int CountryId { get; set; }
        public int SupplierServiceTypeId { get; set; }
    }
}