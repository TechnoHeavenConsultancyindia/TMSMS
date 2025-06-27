using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantDietaryTypeBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        protected RestaurantDietaryTypeBase()
        {

        }

        public RestaurantDietaryTypeBase(string name, string? description = null)
        {

            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantDietaryTypeConsts.NameMaxLength, 0);
            Check.Length(description, nameof(description), RestaurantDietaryTypeConsts.DescriptionMaxLength, 0);
            Name = name;
            Description = description;
        }

    }
}