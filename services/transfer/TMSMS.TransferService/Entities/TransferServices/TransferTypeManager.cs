using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.TransferService.TransferServices
{
    public abstract class TransferTypeManagerBase : DomainService
    {
        protected ITransferTypeRepository _transferTypeRepository;

        public TransferTypeManagerBase(ITransferTypeRepository transferTypeRepository)
        {
            _transferTypeRepository = transferTypeRepository;
        }

        public virtual async Task<TransferType> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TransferTypeConsts.NameMaxLength);

            var transferType = new TransferType(

             name, description
             );

            return await _transferTypeRepository.InsertAsync(transferType);
        }

        public virtual async Task<TransferType> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TransferTypeConsts.NameMaxLength);

            var transferType = await _transferTypeRepository.GetAsync(id);

            transferType.Name = name;
            transferType.Description = description;

            transferType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _transferTypeRepository.UpdateAsync(transferType);
        }

    }
}