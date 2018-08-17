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
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Obtém um restaurante dependente do id
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     GET /Todo
        ///     {
        ///        "id": "d2b8afc3-afe1-49bc-ab92-bb18d150d818"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id do restaurante</param>
        /// <returns>Retorna um restaurante de acordo com o id</returns>
        /// <response code="200">Retorna um restaurante"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(RestaurantVm), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("{id:guid}")]
        public ActionResult<RestaurantVm> Get([FromRoute] Guid id)
        {
            try
            {
                return Ok(_restaurantService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém todos os restaurante dependente do filtro
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     GET /Todo
        ///     {
        ///        "search": "Outback Steakhouse"
        ///     }
        ///
        /// </remarks>
        /// <param name="search">Pesquisa restaurante pelo nome</param>
        /// <returns>Retorna uma lista de restaurantes de acordo com o filtro</returns>
        /// <response code="200">Retorna uma lista de restaurantes"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(IEnumerable<RestaurantVm>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("{search?}")]
        public ActionResult<IEnumerable<RestaurantVm>> GetAll([FromRoute]string search = "")
        {
            try
            {
                return Ok(_restaurantService.Search(r => r.Name.ToLower().Contains(search.ToLower())));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria um restaurante
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "Santa Chiara"
        ///     }
        ///
        /// </remarks>
        /// <param name="restaurant">Objeto restaurante</param>
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="200">Retorna uma mensagem de sucesso: "Operação realizada com sucesso"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("")]
        public ActionResult<string> Add([FromBody] RestaurantVm restaurant)
        {
            try
            {
                ModelState.Remove("RestaurantId");
                if (!ModelState.IsValid) return BadRequest("Campos inválidos");
                _restaurantService.Add(new Restaurant(restaurant.Name));
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita um restaurante
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     PUT /Todo
        ///     {
        ///        "restaurantId": "2821afee-db1c-479b-9e04-28fb911b6cd0",
        ///        "name": "Terra Brasilis Restaurante"
        ///     }
        ///
        /// </remarks>
        /// <param name="restaurant">Objeto restaurante</param>
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="200">Retorna uma mensagem de sucesso: "Operação realizada com sucesso"</response>
        /// <response code="400">Retorna uma mensagem de erro: Objeto nulo ou outra mensagem de acordo com a validação</response>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPut("")]
        public ActionResult<string> Update([FromBody] RestaurantVm restaurant)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Campos inválidos");
                _restaurantService.Update(new Restaurant(restaurant.RestaurantId, restaurant.Name));
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta um restaurante
        /// </summary>
        /// <remarks>
        /// Simples requisição:
        ///
        ///     DELETE /Todo
        ///     {
        ///        "id": "0f0e84fe-f528-4342-900a-fe1f82f0a00c"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id do restaurante</param>
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
                _restaurantService.Remove(id);
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _restaurantService.Dispose();
            base.Dispose(disposing);
        }
    }
}