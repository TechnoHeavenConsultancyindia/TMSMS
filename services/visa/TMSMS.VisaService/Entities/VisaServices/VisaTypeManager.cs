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
    public abstract class VisaTypeManagerBase : DomainService
    {
        protected IVisaTypeRepository _visaTypeRepository;

        public VisaTypeManagerBase(IVisaTypeRepository visaTypeRepository)
        {
            _visaTypeRepository = visaTypeRepository;
        }

        public virtual async Task<VisaType> CreateAsync(
        string name, string? subCategory = null, string? visaPurpose = null, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), VisaTypeConsts.NameMaxLength);
            Check.Length(subCategory, nameof(subCategory), VisaTypeConsts.SubCategoryMaxLength);

            var visaType = new VisaType(

             name, subCategory, visaPurpose, description
             );

            return await _visaTypeRepository.InsertAsync(visaType);
        }

        public virtual async Task<VisaType> UpdateAsync(
            int id,
            string name, string? subCategory = null, string? visaPurpose = null, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), VisaTypeConsts.NameMaxLength);
            Check.Length(subCategory, nameof(subCategory), VisaTypeConsts.SubCategoryMaxLength);

            var visaType = await _visaTypeRepository.GetAsync(id);

            visaType.Name = name;
            visaType.SubCategory = subCategory;
            visaType.VisaPurpose = visaPurpose;
            visaType.Description = description;

            visaType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _visaTypeRepository.UpdateAsync(visaType);
        }

    }
}