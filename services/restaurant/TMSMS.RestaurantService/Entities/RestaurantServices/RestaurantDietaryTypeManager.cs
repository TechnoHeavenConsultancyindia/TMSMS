using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public abstract class RestaurantDietaryTypeManagerBase : DomainService
    {
        protected IRestaurantDietaryTypeRepository _restaurantDietaryTypeRepository;

        public RestaurantDietaryTypeManagerBase(IRestaurantDietaryTypeRepository restaurantDietaryTypeRepository)
        {
            _restaurantDietaryTypeRepository = restaurantDietaryTypeRepository;
        }

        public virtual async Task<RestaurantDietaryType> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantDietaryTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantDietaryTypeConsts.DescriptionMaxLength);

            var restaurantDietaryType = new RestaurantDietaryType(

             name, description
             );

            return await _restaurantDietaryTypeRepository.InsertAsync(restaurantDietaryType);
        }

        public virtual async Task<RestaurantDietaryType> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantDietaryTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantDietaryTypeConsts.DescriptionMaxLength);

            var restaurantDietaryType = await _restaurantDietaryTypeRepository.GetAsync(id);

            restaurantDietaryType.Name = name;
            restaurantDietaryType.Description = description;

            restaurantDietaryType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _restaurantDietaryTypeRepository.UpdateAsync(restaurantDietaryType);
        }

    }
}