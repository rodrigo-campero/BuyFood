using System;
using System.Collections.Generic;
using BuyFood.Domain.Entities;
using BuyFood.Domain.Interfaces.Services;
using BuyFood.Service.WebAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BuyFood.Service.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        /// <summary>
        /// Obtém um prato dependente do id
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     GET /Todo
        ///     {
        ///        "id": "97d9df2e-df0b-49d9-aacf-667e56ed8a61"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id do prato</param>
        /// <returns>Retorna um prato de acordo com o id</returns>
        /// <response code="200">Retorna um prato"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(DishVm), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("{id:guid}")]
        public ActionResult<string> Get([FromRoute] Guid id)
        {
            try
            {
                return Ok(_dishService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém todos os prato dependente do filtro
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     GET /Todo
        ///     {
        ///        "search": "Frango com quiabo"
        ///     }
        ///
        /// </remarks>
        /// <param name="search">Pesquisa prato pelo nome</param>
        /// <returns>Retorna uma lista de pratos de acordo com o filtro</returns>
        /// <response code="200">Retorna uma lista de pratos"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(IEnumerable<DishVm>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("{search?}")]
        public ActionResult<IEnumerable<Dish>> GetAll([FromRoute] string search = "")
        {
            try
            {
                return Ok(_dishService.Search(r => r.Name.ToLower().Contains(search.ToLower())));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria um prato
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "Bambá de couve",
        ///        "price": 10.00,
        ///        "restaurantId": "dfe3f0b7-d65c-45af-8932-c011400e8766
        ///     }
        ///
        /// </remarks>
        /// <param name="dish">Objeto prato</param>
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="200">Retorna uma mensagem de sucesso: "Operação realizada com sucesso"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("")]
        public ActionResult<string> Add([FromBody] DishVm dish)
        {
            try
            {
                ModelState.Remove("DishId");
                if (!ModelState.IsValid) return BadRequest("Campos inválidos");
                _dishService.Add(new Dish(dish.Name, dish.Price, dish.RestaurantId));
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita um prato
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     PUT /Todo
        ///     {
        ///        "dishId": "ca44396d-2257-4988-8a9f-9577a302f72f",
        ///        "name": "Feijão tropeiro",
        ///        "price": 10.00,
        ///        "restaurantId": "3183ea9e-99c5-45c1-affb-18149c4368ff"
        ///     }
        ///
        /// </remarks>
        /// <param name="dish">Objeto prato</param>
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="200">Retorna uma mensagem de sucesso: "Operação realizada com sucesso"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPut("")]
        public ActionResult<string> Update([FromBody] DishVm dish)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Campos inválidos");
                _dishService.Update(new Dish(dish.DishId, dish.Name, dish.Price, dish.RestaurantId));
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta um prato
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     DELETE /Todo
        ///     {
        ///        "id": "3b5c79c3-b18b-4cae-8b71-e4e673fb9dfb"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id do prato</param>
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="200">Retorna uma mensagem de sucesso: "Operação realizada com sucesso"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpDelete("{id:guid}")]
        public ActionResult<string> Remove([FromRoute] Guid id)
        {
            try
            {
                _dishService.Remove(id);
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _dishService.Dispose();
            base.Dispose(disposing);
        }
    }
}