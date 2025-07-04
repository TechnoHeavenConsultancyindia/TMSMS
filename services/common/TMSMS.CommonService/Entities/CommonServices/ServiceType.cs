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
    public abstract class ServiceTypeBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        protected ServiceTypeBase()
        {

        }

        public ServiceTypeBase(string? name = null, string? description = null)
        {

            Check.Length(name, nameof(name), ServiceTypeConsts.NameMaxLength, 0);
            Name = name;
            Description = description;
        }

    }
}