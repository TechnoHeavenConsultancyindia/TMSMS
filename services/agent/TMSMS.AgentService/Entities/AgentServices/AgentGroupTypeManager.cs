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
    public abstract class AgentGroupTypeManagerBase : DomainService
    {
        protected IAgentGroupTypeRepository _agentGroupTypeRepository;

        public AgentGroupTypeManagerBase(IAgentGroupTypeRepository agentGroupTypeRepository)
        {
            _agentGroupTypeRepository = agentGroupTypeRepository;
        }

        public virtual async Task<AgentGroupType> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), AgentGroupTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), AgentGroupTypeConsts.DescriptionMaxLength);

            var agentGroupType = new AgentGroupType(

             name, description
             );

            return await _agentGroupTypeRepository.InsertAsync(agentGroupType);
        }

        public virtual async Task<AgentGroupType> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), AgentGroupTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), AgentGroupTypeConsts.DescriptionMaxLength);

            var agentGroupType = await _agentGroupTypeRepository.GetAsync(id);

            agentGroupType.Name = name;
            agentGroupType.Description = description;

            agentGroupType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _agentGroupTypeRepository.UpdateAsync(agentGroupType);
        }

    }
}