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
    public abstract class VisaTermCategoryManagerBase : DomainService
    {
        protected IVisaTermCategoryRepository _visaTermCategoryRepository;

        public VisaTermCategoryManagerBase(IVisaTermCategoryRepository visaTermCategoryRepository)
        {
            _visaTermCategoryRepository = visaTermCategoryRepository;
        }

        public virtual async Task<VisaTermCategory> CreateAsync(
        string? name = null, string? description = null)
        {
            Check.Length(name, nameof(name), VisaTermCategoryConsts.NameMaxLength);
            Check.Length(description, nameof(description), VisaTermCategoryConsts.DescriptionMaxLength);

            var visaTermCategory = new VisaTermCategory(

             name, description
             );

            return await _visaTermCategoryRepository.InsertAsync(visaTermCategory);
        }

        public virtual async Task<VisaTermCategory> UpdateAsync(
            int id,
            string? name = null, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.Length(name, nameof(name), VisaTermCategoryConsts.NameMaxLength);
            Check.Length(description, nameof(description), VisaTermCategoryConsts.DescriptionMaxLength);

            var visaTermCategory = await _visaTermCategoryRepository.GetAsync(id);

            visaTermCategory.Name = name;
            visaTermCategory.Description = description;

            visaTermCategory.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _visaTermCategoryRepository.UpdateAsync(visaTermCategory);
        }

    }
}