using TMSMS.CommonService;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(SupplierMasterConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        public SupplierType Type { get; set; }
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
        public SupplierStatus SupplierStatus { get; set; }
        public bool Preffered { get; set; }
        public int CountryId { get; set; }
        public int SupplierServiceTypeId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}