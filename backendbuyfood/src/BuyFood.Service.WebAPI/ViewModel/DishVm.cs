using System;
using System.ComponentModel.DataAnnotations;

namespace BuyFood.Service.WebAPI.ViewModel
{
    public class DishVm
    {
        #region Properties

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid DishId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get; set; }

        #endregion

        #region Maps

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid RestaurantId { get; set; }

        #endregion
    }
}