using System;
using System.ComponentModel.DataAnnotations;

namespace BuyFood.Service.WebAPI.ViewModel
{
    public class RestaurantVm
    {
        #region Properties

        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public Guid RestaurantId { get; set; }
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Name { get; set; }

        #endregion
    }
}