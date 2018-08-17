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
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(MainContext context) : base(context) { }

        public override IEnumerable<Restaurant> Search(Expression<Func<Restaurant, bool>> predicate)
        {
            return DbSet.Include(x => x.Dishes).Where(predicate);
        }
    }
}
