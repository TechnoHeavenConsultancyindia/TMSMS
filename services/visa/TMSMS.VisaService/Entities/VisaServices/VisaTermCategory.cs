using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaTermCategoryBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        protected VisaTermCategoryBase()
        {

        }

        public VisaTermCategoryBase(string? name = null, string? description = null)
        {

            Check.Length(name, nameof(name), VisaTermCategoryConsts.NameMaxLength, 0);
            Check.Length(description, nameof(description), VisaTermCategoryConsts.DescriptionMaxLength, 0);
            Name = name;
            Description = description;
        }

    }
}