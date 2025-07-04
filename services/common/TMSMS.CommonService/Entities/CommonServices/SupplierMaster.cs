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

        [CanBeNull]
        public virtual string? Type { get; set; }

        [NotNull]
        public virtual string ContactName { get; set; }

        [CanBeNull]
        public virtual string? ContactEmail { get; set; }

        [CanBeNull]
        public virtual string? DialCode { get; set; }

        [CanBeNull]
        public virtual string? ContactPhone { get; set; }

        public virtual int SupplierStatus { get; set; }

        public virtual bool Preffered { get; set; }
        public int CountryId { get; set; }
        public int SupplierServiceTypeId { get; set; }

        protected SupplierMasterBase()
        {

        }

        public SupplierMasterBase(int countryId, int supplierServiceTypeId, string name, string contactName, int supplierStatus, bool preffered, string? type = null, string? contactEmail = null, string? dialCode = null, string? contactPhone = null)
        {

            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), SupplierMasterConsts.NameMaxLength, 0);
            Check.NotNull(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), SupplierMasterConsts.ContactNameMaxLength, 0);
            Check.Length(contactEmail, nameof(contactEmail), SupplierMasterConsts.ContactEmailMaxLength, 0);
            Check.Length(dialCode, nameof(dialCode), SupplierMasterConsts.DialCodeMaxLength, 0);
            Check.Length(contactPhone, nameof(contactPhone), SupplierMasterConsts.ContactPhoneMaxLength, 0);
            Name = name;
            ContactName = contactName;
            SupplierStatus = supplierStatus;
            Preffered = preffered;
            Type = type;
            ContactEmail = contactEmail;
            DialCode = dialCode;
            ContactPhone = contactPhone;
            CountryId = countryId;
            SupplierServiceTypeId = supplierServiceTypeId;
        }

    }
}