using api_univesp_pji240_farm_manager.DTO;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Interface.Data
{
    public interface IDataProductRepository
    {
        Task AddProduct(ProductDTO productDTO, MySqlConnection connection);
        Task<List<ProductDTO>> GetAllProducts(MySqlConnection connection);
        List<CategoryDTO> GetCategories(MySqlConnection connection);
        Task RemoveProduct(ProductDTO productDTO, MySqlConnection connection);
        Task UpateProduct(ProductDTO productDTO, MySqlConnection connection);
    }
}
