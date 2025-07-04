using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class SupplierMasterManagerBase : DomainService
    {
        protected ISupplierMasterRepository _supplierMasterRepository;

        public SupplierMasterManagerBase(ISupplierMasterRepository supplierMasterRepository)
        {
            _supplierMasterRepository = supplierMasterRepository;
        }

        public virtual async Task<SupplierMaster> CreateAsync(
        int countryId, int supplierServiceTypeId, string name, string contactName, int supplierStatus, bool preffered, string? type = null, string? contactEmail = null, string? dialCode = null, string? contactPhone = null)
        {
            Check.NotNull(countryId, nameof(countryId));
            Check.NotNull(supplierServiceTypeId, nameof(supplierServiceTypeId));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SupplierMasterConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), SupplierMasterConsts.ContactNameMaxLength);
            Check.Length(contactEmail, nameof(contactEmail), SupplierMasterConsts.ContactEmailMaxLength);
            Check.Length(dialCode, nameof(dialCode), SupplierMasterConsts.DialCodeMaxLength);
            Check.Length(contactPhone, nameof(contactPhone), SupplierMasterConsts.ContactPhoneMaxLength);

            var supplierMaster = new SupplierMaster(

             countryId, supplierServiceTypeId, name, contactName, supplierStatus, preffered, type, contactEmail, dialCode, contactPhone
             );

            return await _supplierMasterRepository.InsertAsync(supplierMaster);
        }

        public virtual async Task<SupplierMaster> UpdateAsync(
            int id,
            int countryId, int supplierServiceTypeId, string name, string contactName, int supplierStatus, bool preffered, string? type = null, string? contactEmail = null, string? dialCode = null, string? contactPhone = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(countryId, nameof(countryId));
            Check.NotNull(supplierServiceTypeId, nameof(supplierServiceTypeId));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SupplierMasterConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), SupplierMasterConsts.ContactNameMaxLength);
            Check.Length(contactEmail, nameof(contactEmail), SupplierMasterConsts.ContactEmailMaxLength);
            Check.Length(dialCode, nameof(dialCode), SupplierMasterConsts.DialCodeMaxLength);
            Check.Length(contactPhone, nameof(contactPhone), SupplierMasterConsts.ContactPhoneMaxLength);

            var supplierMaster = await _supplierMasterRepository.GetAsync(id);

            supplierMaster.CountryId = countryId;
            supplierMaster.SupplierServiceTypeId = supplierServiceTypeId;
            supplierMaster.Name = name;
            supplierMaster.ContactName = contactName;
            supplierMaster.SupplierStatus = supplierStatus;
            supplierMaster.Preffered = preffered;
            supplierMaster.Type = type;
            supplierMaster.ContactEmail = contactEmail;
            supplierMaster.DialCode = dialCode;
            supplierMaster.ContactPhone = contactPhone;

            supplierMaster.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _supplierMasterRepository.UpdateAsync(supplierMaster);
        }

    }
}