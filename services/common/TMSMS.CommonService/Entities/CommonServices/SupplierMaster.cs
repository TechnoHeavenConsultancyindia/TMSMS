using TMSMS.CommonService;
using TMSMS.CommonService.CommonServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public virtual SupplierType Type { get; set; }

        [NotNull]
        public virtual string ContactName { get; set; }

        [CanBeNull]
        public virtual string? ContactEmail { get; set; }

        [CanBeNull]
        public virtual string? DialCode { get; set; }

        [CanBeNull]
        public virtual string? ContactPhone { get; set; }

        public virtual SupplierStatus SupplierStatus { get; set; }

        public virtual bool Preffered { get; set; }
        public int CountryId { get; set; }
        public int SupplierServiceTypeId { get; set; }

        protected SupplierMasterBase()
        {

        }

        public SupplierMasterBase(int countryId, int supplierServiceTypeId, string name, SupplierType type, string contactName, SupplierStatus supplierStatus, bool preffered, string? contactEmail = null, string? dialCode = null, string? contactPhone = null)
        {

            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), SupplierMasterConsts.NameMaxLength, 0);
            Check.NotNull(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), SupplierMasterConsts.ContactNameMaxLength, 0);
            Check.Length(contactEmail, nameof(contactEmail), SupplierMasterConsts.ContactEmailMaxLength, 0);
            Check.Length(dialCode, nameof(dialCode), SupplierMasterConsts.DialCodeMaxLength, 0);
            Check.Length(contactPhone, nameof(contactPhone), SupplierMasterConsts.ContactPhoneMaxLength, 0);
            Name = name;
            Type = type;
            ContactName = contactName;
            SupplierStatus = supplierStatus;
            Preffered = preffered;
            ContactEmail = contactEmail;
            DialCode = dialCode;
            ContactPhone = contactPhone;
            CountryId = countryId;
            SupplierServiceTypeId = supplierServiceTypeId;
        }

    }
}