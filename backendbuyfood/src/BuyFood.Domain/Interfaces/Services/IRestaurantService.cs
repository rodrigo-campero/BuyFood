using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BuyFood.Domain.Entities;
namespace BuyFood.Domain.Interfaces.Services
{
    public interface IRestaurantService : IDisposable
    {
        Restaurant Add(Restaurant obj);
        Restaurant Update(Restaurant obj);
        void Remove(Guid id);
        Restaurant GetById(Guid id);
        IEnumerable<Restaurant> Search(Expression<Func<Restaurant, bool>> predicate);
    }
}
