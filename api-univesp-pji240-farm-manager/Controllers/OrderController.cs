using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {

        private readonly MySqlConnection _connection;
        private readonly IDataOrderRepository _data;

        public OrderController(MySqlConnection connection
            , IDataOrderRepository data)
        {
            _connection = connection;
            _data = data;
        }


        [HttpGet]
        public async Task<List<OrderDTO>> GetPendingOrders()
        {

            List<OrderDTO> response = new List<OrderDTO>();
            await _connection.OpenAsync();

            response = await _data.GetPendingOrders(_connection);

            _connection.Close();

            return response;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<ActionResult> AddOrder(OrderDTO request)
        {
            await _connection.OpenAsync();

            long orderId = await _data.AddOrder(request, _connection);
            if (orderId > 0)
            {
                request.OrderId = orderId;
                await _data.AddOrderItems(request, _connection);
            }

            _connection.Close();

            return Ok();

        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<ActionResult> UpdateOrder(int orderId, int statusId)
        {
            await _connection.OpenAsync();

            await _data.UpateOrder(orderId, statusId, _connection);

            _connection.Close();

            return Ok();

        }

        [HttpPut]
        [Route("ChangePayment")]
        public async Task<ActionResult> UpdatePayment(int orderId, bool paymentStatus)
        {
            await _connection.OpenAsync();

            await _data.ChangePayment(orderId, paymentStatus, _connection);

            _connection.Close();

            return Ok();

        }

        [HttpPut]
        [Route("ConfirmDelivery")]
        public async Task<ActionResult> ConfirmDelivery(int orderId)
        {
            await _connection.OpenAsync();

            await _data.ConfirmDelivery(orderId, _connection);

            _connection.Close();

            return Ok();

        }
    }
}
