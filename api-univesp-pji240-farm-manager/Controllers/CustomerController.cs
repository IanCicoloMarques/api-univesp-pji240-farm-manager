using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {

        private readonly MySqlConnection _connection;
        private readonly IDataCustomerRepository _data;

        public CustomerController(MySqlConnection connection
            , IDataCustomerRepository data)
        {
            _connection = connection;
            _data = data;
        }


        [HttpGet]
        [Route("GetCustomerList")]
        public async Task<List<CustomerDTO>> GetCustomerList()
        {
            List<CustomerDTO> response = new List<CustomerDTO>();

            await _connection.OpenAsync();

            response = await _data.GetCustomerList(_connection);

            _connection.Close();

            return response;
        }

        [HttpPost]
        [Route("RegisterCustomer")]
        public async Task<ActionResult> RegisterCustomer(CustomerDTO customer)
        {
            await _connection.OpenAsync();

            await _data.RegisterCustumer(customer, _connection);

            _connection.Close();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveCustomer(int id)
        {
            await _connection.OpenAsync();

            await _data.RemoveCustumer(id, _connection);

            _connection.Close();

            return Ok();
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer(CustomerDTO customer)
        {
            await _connection.OpenAsync();

            await _data.UpateCustomer(customer, _connection);

            _connection.Close();

            return Ok();
        }
    }
}
