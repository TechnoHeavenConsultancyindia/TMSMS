using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class VisaDiscountCategoryManagerBase : DomainService
    {
        protected IVisaDiscountCategoryRepository _visaDiscountCategoryRepository;

        public VisaDiscountCategoryManagerBase(IVisaDiscountCategoryRepository visaDiscountCategoryRepository)
        {
            _visaDiscountCategoryRepository = visaDiscountCategoryRepository;
        }

        public virtual async Task<VisaDiscountCategory> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), VisaDiscountCategoryConsts.NameMaxLength);
            Check.Length(description, nameof(description), VisaDiscountCategoryConsts.DescriptionMaxLength);

            var visaDiscountCategory = new VisaDiscountCategory(

             name, description
             );

            return await _visaDiscountCategoryRepository.InsertAsync(visaDiscountCategory);
        }

        public virtual async Task<VisaDiscountCategory> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), VisaDiscountCategoryConsts.NameMaxLength);
            Check.Length(description, nameof(description), VisaDiscountCategoryConsts.DescriptionMaxLength);

            var visaDiscountCategory = await _visaDiscountCategoryRepository.GetAsync(id);

            visaDiscountCategory.Name = name;
            visaDiscountCategory.Description = description;

            visaDiscountCategory.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _visaDiscountCategoryRepository.UpdateAsync(visaDiscountCategory);
        }

    }
}