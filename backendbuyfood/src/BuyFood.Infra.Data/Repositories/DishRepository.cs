using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BuyFood.Domain.Entities;
using BuyFood.Domain.Interfaces.Repositories;
using BuyFood.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BuyFood.Infra.Data.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(MainContext context) : base(context) { }

        public override IEnumerable<Dish> Search(Expression<Func<Dish, bool>> predicate)
        {
            return DbSet.Include(x => x.Restaurant).Where(predicate);
        }
    }
}
