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
        public string? Type { get; set; }
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
        public int SupplierStatus { get; set; }
        public bool Preffered { get; set; }
        public int CountryId { get; set; }
        public int SupplierServiceTypeId { get; set; }
    }
}