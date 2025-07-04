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
    public abstract class ServiceTypeManagerBase : DomainService
    {
        protected IServiceTypeRepository _serviceTypeRepository;

        public ServiceTypeManagerBase(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public virtual async Task<ServiceType> CreateAsync(
        string? name = null, string? description = null)
        {
            Check.Length(name, nameof(name), ServiceTypeConsts.NameMaxLength);

            var serviceType = new ServiceType(

             name, description
             );

            return await _serviceTypeRepository.InsertAsync(serviceType);
        }

        public virtual async Task<ServiceType> UpdateAsync(
            int id,
            string? name = null, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.Length(name, nameof(name), ServiceTypeConsts.NameMaxLength);

            var serviceType = await _serviceTypeRepository.GetAsync(id);

            serviceType.Name = name;
            serviceType.Description = description;

            serviceType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _serviceTypeRepository.UpdateAsync(serviceType);
        }

    }
}