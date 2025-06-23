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
    public abstract class AgentPermissionTypeManagerBase : DomainService
    {
        protected IAgentPermissionTypeRepository _agentPermissionTypeRepository;

        public AgentPermissionTypeManagerBase(IAgentPermissionTypeRepository agentPermissionTypeRepository)
        {
            _agentPermissionTypeRepository = agentPermissionTypeRepository;
        }

        public virtual async Task<AgentPermissionType> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), AgentPermissionTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), AgentPermissionTypeConsts.DescriptionMaxLength);

            var agentPermissionType = new AgentPermissionType(

             name, description
             );

            return await _agentPermissionTypeRepository.InsertAsync(agentPermissionType);
        }

        public virtual async Task<AgentPermissionType> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), AgentPermissionTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), AgentPermissionTypeConsts.DescriptionMaxLength);

            var agentPermissionType = await _agentPermissionTypeRepository.GetAsync(id);

            agentPermissionType.Name = name;
            agentPermissionType.Description = description;

            agentPermissionType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _agentPermissionTypeRepository.UpdateAsync(agentPermissionType);
        }

    }
}