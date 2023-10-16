using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;


namespace api_univesp_pji240_farm_manager.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly MySqlConnection _connection;
        private readonly IDataProductRepository _data;

        public ProductController(MySqlConnection connection
            , IDataProductRepository data)
        {
            _connection = connection;
            _data = data;
        }


        [HttpGet]
        public async Task<List<ProductDTO>> GetCustomerList()
        {

            List<ProductDTO> response = new List<ProductDTO> ();
            await _connection.OpenAsync();

            response = await _data.GetAllProducts(_connection);

            _connection.Close();

            return response;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct(ProductDTO request)
        {
            await _connection.OpenAsync();

            await _data.AddProduct(request, _connection);

            _connection.Close();

            return Ok();

        }

    }
}
