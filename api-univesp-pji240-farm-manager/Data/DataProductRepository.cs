using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
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

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"SELECT* 
                                    FROM products P
                                    WHERE P.removed = 0";

            using MySqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                ProductDTO product = new ProductDTO();
                product.ProductId = reader.GetInt32(0);
                product.Name = reader.GetString(1);
                product.Price = reader.GetDecimal(2);
                product.Image = reader.GetString(3);
                response.Add(product);
            }

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
