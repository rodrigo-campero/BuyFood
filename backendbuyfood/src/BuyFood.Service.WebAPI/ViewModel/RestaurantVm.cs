using System;
using System.ComponentModel.DataAnnotations;

namespace BuyFood.Service.WebAPI.ViewModel
{
    public class RestaurantVm
    {
        #region Properties

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid RestaurantId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        #endregion
    }
}