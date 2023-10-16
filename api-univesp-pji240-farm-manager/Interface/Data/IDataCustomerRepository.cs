using api_univesp_pji240_farm_manager.DTO;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Interface.Data
{
    public interface IDataCustomerRepository
    {
        Task RegisterCustumer(CustomerDTO customer, MySqlConnection connection);
        Task<List<CustomerDTO>> GetCustomerList(MySqlConnection connection);
        Task RemoveCustumer(int id, MySqlConnection connection);
        Task UpateCustomer(CustomerDTO customer, MySqlConnection connection);
    }
}
