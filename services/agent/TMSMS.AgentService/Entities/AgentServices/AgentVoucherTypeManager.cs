using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentVoucherTypeManagerBase : DomainService
    {
        protected IAgentVoucherTypeRepository _agentVoucherTypeRepository;

        public AgentVoucherTypeManagerBase(IAgentVoucherTypeRepository agentVoucherTypeRepository)
        {
            _agentVoucherTypeRepository = agentVoucherTypeRepository;
        }

        public virtual async Task<AgentVoucherType> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), AgentVoucherTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), AgentVoucherTypeConsts.DescriptionMaxLength);

            var agentVoucherType = new AgentVoucherType(

             name, description
             );

            return await _agentVoucherTypeRepository.InsertAsync(agentVoucherType);
        }

        public virtual async Task<AgentVoucherType> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), AgentVoucherTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), AgentVoucherTypeConsts.DescriptionMaxLength);

            var agentVoucherType = await _agentVoucherTypeRepository.GetAsync(id);

            agentVoucherType.Name = name;
            agentVoucherType.Description = description;

            agentVoucherType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _agentVoucherTypeRepository.UpdateAsync(agentVoucherType);
        }

    }
}