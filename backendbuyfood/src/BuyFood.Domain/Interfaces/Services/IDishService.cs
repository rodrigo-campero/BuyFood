using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BuyFood.Domain.Entities;
namespace BuyFood.Domain.Interfaces.Services
{
    public interface IDishService : IDisposable
    {
        Dish Add(Dish obj);
        Dish Update(Dish obj);
        void Remove(Guid id);
        Dish GetById(Guid id);
        IEnumerable<Dish> Search(Expression<Func<Dish, bool>> predicate);
    }
}
