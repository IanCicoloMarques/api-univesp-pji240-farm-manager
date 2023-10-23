using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using Dapper;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Data
{
    public class DataProductRepository : IDataProductRepository
    {
        public async Task AddProduct(ProductDTO productDTO, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"INSERT INTO
                                        products
                                            (product_name, price, product_image)
                                        VALUES
                                            (@product_name, @price, @product_image)";
           
            command.Parameters.AddWithValue("@product_name", productDTO.Name);
            command.Parameters.AddWithValue("@price", productDTO.Price);
            command.Parameters.AddWithValue("@product_image", productDTO.Image);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<ProductDTO>> GetAllProducts(MySqlConnection connection)
        {
            List<ProductDTO> response = new List<ProductDTO>();

            string query = @"SELECT P.product_Id AS ProductId,
                                           P.product_name AS Name,
                                           P.price AS Price,
                                           P.product_image AS Image,
                                           C.name AS Category
                                    FROM products P
                                    LEFT JOIN categories C ON C.category_id = P.category_id
                                    WHERE P.removed = 0";

            response = connection.Query<ProductDTO>(query).ToList();
            
            

            return response;
        }

        public List<CategoryDTO> GetCategories(MySqlConnection connection)
        {
            List<CategoryDTO> response = new List<CategoryDTO>();
            string query = @"SELECT *, category_id AS ID
                                    FROM categories P";

            response = connection.Query<CategoryDTO>(query).ToList();
            return response;
        }

        public async Task RemoveProduct(ProductDTO productDTO, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"UPDATE products
                                    SET
                                        removed = 1
                                      , removed_at = CURRENT_TIMESTAMP
                                    WHERE product_id = @id";

            command.Parameters.AddWithValue("@id", productDTO.ProductId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task UpateProduct(ProductDTO productDTO, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"UPDATE products
                                    SET
                                        product_name = @product_name
                                      , product_image = @product_image
                                      , price = @price
                                      , updated_at = CURRENT_TIMESTAMP
                                    WHERE product_id = @id";

            command.Parameters.AddWithValue("@id", productDTO.ProductId);

            command.Parameters.AddWithValue("@product_name", productDTO.Name);
            command.Parameters.AddWithValue("@price", productDTO.Price);
            command.Parameters.AddWithValue("@product_image", productDTO.Image);

            await command.ExecuteNonQueryAsync();
        }
    }
}
