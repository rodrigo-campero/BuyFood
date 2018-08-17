using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BuyFood.Domain.Entities;
using BuyFood.Domain.Interfaces;
using BuyFood.Domain.Interfaces.Repositories;
using BuyFood.Domain.Interfaces.Services;
namespace BuyFood.Domain.Services
{
    public class RestaurantService : BaseService, IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IUnitOfWork uow, IRestaurantRepository restaurantRepository) : base(uow)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant Add(Restaurant obj)
        {
            BeginTransaction();
            obj = _restaurantRepository.Add(obj);
            Commit();
            return obj;
        }

        public Restaurant Update(Restaurant obj)
        {
            BeginTransaction();
            var restaurant = GetById(obj.RestaurantId);
            if (restaurant == null) throw new ArgumentNullException(nameof(restaurant));
            restaurant.Update(obj);
            obj = _restaurantRepository.Update(restaurant);
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _restaurantRepository.Remove(GetById(id));
            Commit();
        }

        public Restaurant GetById(Guid id)
        {
            return _restaurantRepository.GetById(id);
        }

        public IEnumerable<Restaurant> Search(Expression<Func<Restaurant, bool>> predicate)
        {
            return _restaurantRepository.Search(predicate);
        }

        public void Dispose()
        {
            _restaurantRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
