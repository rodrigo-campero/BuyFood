using System;

namespace BuyFood.Domain.Entities
{
    public class Dish
    {
        public Dish(string name, decimal price, Guid restaurantId)
        {
            Name = name;
            Price = price;
            RestaurantId = restaurantId;
        }

        public Dish(Guid dishId, string name, decimal price, Guid restaurantId)
        {
            DishId = dishId;
            Name = name;
            Price = price;
            RestaurantId = restaurantId;
        }

        private Dish()
        {

        }

        #region Properties

        public Guid DishId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        #endregion

        #region Maps

        public Restaurant Restaurant { get; set; }
        public Guid RestaurantId { get; set; }

        #endregion

        #region Methods

        public void Update(Dish dish)
        {
            RestaurantId = dish.RestaurantId;
            Name = dish.Name;
            Price = dish.Price;
        }

        #endregion
    }
}
