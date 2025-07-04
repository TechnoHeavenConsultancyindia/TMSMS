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
    public abstract class SupplierServiceTypeManagerBase : DomainService
    {
        protected ISupplierServiceTypeRepository _supplierServiceTypeRepository;

        public SupplierServiceTypeManagerBase(ISupplierServiceTypeRepository supplierServiceTypeRepository)
        {
            _supplierServiceTypeRepository = supplierServiceTypeRepository;
        }

        public virtual async Task<SupplierServiceType> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SupplierServiceTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), SupplierServiceTypeConsts.DescriptionMaxLength);

            var supplierServiceType = new SupplierServiceType(

             name, description
             );

            return await _supplierServiceTypeRepository.InsertAsync(supplierServiceType);
        }

        public virtual async Task<SupplierServiceType> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), SupplierServiceTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), SupplierServiceTypeConsts.DescriptionMaxLength);

            var supplierServiceType = await _supplierServiceTypeRepository.GetAsync(id);

            supplierServiceType.Name = name;
            supplierServiceType.Description = description;

            supplierServiceType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _supplierServiceTypeRepository.UpdateAsync(supplierServiceType);
        }

    }
}