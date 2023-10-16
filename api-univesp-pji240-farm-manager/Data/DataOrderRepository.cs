using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Data
{
    public class DataOrderRepository : IDataOrderRepository
    {
        public Task AddOrder(OrderDTO order, MySqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDTO>> GetAllOrders(MySqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrder(OrderDTO order, MySqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public Task UpateOrder(OrderDTO order, MySqlConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
