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
    public abstract class RestaurantTagManagerBase : DomainService
    {
        protected IRestaurantTagRepository _restaurantTagRepository;

        public RestaurantTagManagerBase(IRestaurantTagRepository restaurantTagRepository)
        {
            _restaurantTagRepository = restaurantTagRepository;
        }

        public virtual async Task<RestaurantTag> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantTagConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantTagConsts.DescriptionMaxLength);

            var restaurantTag = new RestaurantTag(

             name, description
             );

            return await _restaurantTagRepository.InsertAsync(restaurantTag);
        }

        public virtual async Task<RestaurantTag> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantTagConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantTagConsts.DescriptionMaxLength);

            var restaurantTag = await _restaurantTagRepository.GetAsync(id);

            restaurantTag.Name = name;
            restaurantTag.Description = description;

            restaurantTag.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _restaurantTagRepository.UpdateAsync(restaurantTag);
        }

    }
}