using System;
using System.Collections.Generic;
namespace BuyFood.Domain.Entities
{
    public class Restaurant
    {
        public Restaurant(string name)
        {
            Name = name;
        }

        public Restaurant(Guid restaurantId, string name)
        {
            RestaurantId = restaurantId;
            Name = name;
        }

        private Restaurant()
        {

        }

        #region Properties

        public Guid RestaurantId { get; set; }
        public string Name { get; set; }

        #endregion

        #region Maps

        public ICollection<Dish> Dishes { get; set; }

        #endregion

        #region Methods

        public void Update(Restaurant restaurant)
        {
            Name = restaurant.Name;
        }

        #endregion
    }
}
