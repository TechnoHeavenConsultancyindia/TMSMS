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
    public abstract class VisaTypeBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? SubCategory { get; set; }

        [CanBeNull]
        public virtual string? VisaPurpose { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        protected VisaTypeBase()
        {

        }

        public VisaTypeBase(string name, string? subCategory = null, string? visaPurpose = null, string? description = null)
        {

            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), VisaTypeConsts.NameMaxLength, 0);
            Check.Length(subCategory, nameof(subCategory), VisaTypeConsts.SubCategoryMaxLength, 0);
            Name = name;
            SubCategory = subCategory;
            VisaPurpose = visaPurpose;
            Description = description;
        }

    }
}