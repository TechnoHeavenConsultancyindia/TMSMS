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
    public abstract class RestaurantCuisineManagerBase : DomainService
    {
        protected IRestaurantCuisineRepository _restaurantCuisineRepository;

        public RestaurantCuisineManagerBase(IRestaurantCuisineRepository restaurantCuisineRepository)
        {
            _restaurantCuisineRepository = restaurantCuisineRepository;
        }

        public virtual async Task<RestaurantCuisine> CreateAsync(
        string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantCuisineConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantCuisineConsts.DescriptionMaxLength);

            var restaurantCuisine = new RestaurantCuisine(

             name, description
             );

            return await _restaurantCuisineRepository.InsertAsync(restaurantCuisine);
        }

        public virtual async Task<RestaurantCuisine> UpdateAsync(
            int id,
            string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), RestaurantCuisineConsts.NameMaxLength);
            Check.Length(description, nameof(description), RestaurantCuisineConsts.DescriptionMaxLength);

            var restaurantCuisine = await _restaurantCuisineRepository.GetAsync(id);

            restaurantCuisine.Name = name;
            restaurantCuisine.Description = description;

            restaurantCuisine.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _restaurantCuisineRepository.UpdateAsync(restaurantCuisine);
        }

    }
}