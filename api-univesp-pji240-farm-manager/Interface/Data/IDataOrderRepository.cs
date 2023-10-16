using api_univesp_pji240_farm_manager.DTO;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Interface.Data
{
    public interface IDataOrderRepository
    {
        Task AddOrder(OrderDTO order, MySqlConnection connection);
        Task<List<OrderDTO>> GetAllOrders(MySqlConnection connection);
        Task RemoveOrder(OrderDTO order, MySqlConnection connection);
        Task UpateOrder(OrderDTO order, MySqlConnection connection);
    }
}
