using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using MySqlConnector;

namespace api_univesp_pji240_farm_manager.Data
{
    public class DataCustomerRepository : IDataCustomerRepository
    {
        public async Task<List<CustomerDTO>> GetCustomerList(MySqlConnection connection)
        {
            List<CustomerDTO> response = new List<CustomerDTO>();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"SELECT* 
                                    FROM customer P
                                    WHERE P.removed = 0";

            using MySqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                CustomerDTO customer = new CustomerDTO();

                customer.id = reader.GetInt32(0);
                customer.FirstName = reader.GetString(1);
                customer.LastName = reader.GetString(2);
                customer.Email = reader.GetString(3);
                customer.Address1 = reader.GetString(4);
                customer.Address2 = reader.GetString(5);
                customer.Address3 = reader.GetString(6);
                customer.Phone = reader.GetString(7);

                response.Add(customer);
            }

            return response;
        }

        public async Task RegisterCustumer(CustomerDTO customer, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"INSERT INTO
                                        customers
                                            (first_name, last_name, email, address_1, address_2, address_3, phone)
                                        VALUES
                                            (@first_name, @last_name, @email, @address_1, @address_2, @address_3, @phone)";

            command.Parameters.AddWithValue("@first_name", customer.FirstName);
            command.Parameters.AddWithValue("@last_name", customer.LastName);
            command.Parameters.AddWithValue("@email", customer.Email);
            command.Parameters.AddWithValue("@address_1", customer.Address1);
            command.Parameters.AddWithValue("@address_2", customer.Address2);
            command.Parameters.AddWithValue("@address_3", customer.Address3);
            command.Parameters.AddWithValue("@phone", customer.Phone);

            await command.ExecuteNonQueryAsync();
        }

        public async Task RemoveCustumer(int id, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"UPDATE customers
                                    SET
                                        removed = 1
                                      , removed_at = CURRENT_TIMESTAMP
                                    WHERE product_id = @id";

            command.Parameters.AddWithValue("@id", id);

            await command.ExecuteNonQueryAsync();


        }

        public async Task UpateCustomer(CustomerDTO customer, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"UPDATE customers
                                    SET
                                        first_name = @first_name
                                      , last_name = @last_name
                                      , email = @email
                                      , address_1 = @address_1
                                      , address_2 = @address_2
                                      , address_3 = @address_3
                                      , phone = @phone
                                      , updated_at = CURRENT_TIMESTAMP
                                    WHERE product_id = @id";

            command.Parameters.AddWithValue("@id", customer.id);

            command.Parameters.AddWithValue("@first_name", customer.FirstName);
            command.Parameters.AddWithValue("@last_name", customer.LastName);
            command.Parameters.AddWithValue("@email", customer.Email);
            command.Parameters.AddWithValue("@address_1", customer.Address1);
            command.Parameters.AddWithValue("@address_2", customer.Address2);
            command.Parameters.AddWithValue("@address_3", customer.Address3);
            command.Parameters.AddWithValue("@phone", customer.Phone);

            await command.ExecuteNonQueryAsync();
        }
    }
}
