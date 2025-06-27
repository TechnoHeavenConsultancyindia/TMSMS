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
    public abstract class RestaurantTypeManagerBase : DomainService
    {
        protected IRestaurantTypeRepository _restaurantTypeRepository;

        public RestaurantTypeManagerBase(IRestaurantTypeRepository restaurantTypeRepository)
        {
            _restaurantTypeRepository = restaurantTypeRepository;
        }

        public virtual async Task<RestaurantType> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantTypeConsts.DescriptionMaxLength);

            var restaurantType = new RestaurantType(

             name, description
             );

            return await _restaurantTypeRepository.InsertAsync(restaurantType);
        }

        public virtual async Task<RestaurantType> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantTypeConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantTypeConsts.DescriptionMaxLength);

            var restaurantType = await _restaurantTypeRepository.GetAsync(id);

            restaurantType.Name = name;
            restaurantType.Description = description;

            restaurantType.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _restaurantTypeRepository.UpdateAsync(restaurantType);
        }

    }
}