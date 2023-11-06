using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using MySqlConnector;
using System.Globalization;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace api_univesp_pji240_farm_manager.Data
{
    public class DataOrderRepository : IDataOrderRepository
    {
        public async Task<long> AddOrder(OrderDTO order, MySqlConnection connection)
        {
            long result = 0;
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = @"INSERT INTO orders
                                            (customer_id, order_status_id, is_paid)
                                        VALUES
                                            (@customer_id, 1, @is_paid)";

            command.Parameters.AddWithValue("@is_paid", order.isPaid);
            command.Parameters.AddWithValue("@customer_id", order.CustomerId);

            await command.ExecuteNonQueryAsync();
            result = command.LastInsertedId;

            return result;
        }

        public async Task AddOrderItems(OrderDTO order, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            string query = @"INSERT INTO orderitems
                                (customer_id, order_id, amount, price, product_name, product_id)
                            VALUES ";
            foreach (ProductDTO product in order.ProductList)
            {
                string value = string.Format(@"('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'),", order.CustomerId, order.OrderId, product.Amount, product.Price.ToString(CultureInfo.InvariantCulture), product.Name, product.ProductId);
                query = query + value;
            }

            query = query.TrimEnd(',');

            command.CommandText = query;
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<OrderDTO>> GetAllOrders(MySqlConnection connection)
        {
            List<OrderDTO> response = new List<OrderDTO>();

            string query = @"SELECT
                                O.customer_id AS CustomerId,
                                CONCAT(C.first_name, ' ', C.last_name) AS CustomerName,
                                CONCAT(C.address_1, ', ', C.address_3, ' - CEP: ', C.address_2) AS FullAddress,
                                DATE_FORMAT(O.estimated_delivery , '%d/%m/%Y') as EstimatedDelivery,
                                DATE_FORMAT(O.created_at , '%d/%m/%Y') as OrderedAt,
                                OC.status_description as StatusDescription,
                                O.is_paid AS isPaid,
                                O.order_id AS OrderId,
                                OI.order_Id AS Id,
                                OI.product_Id as ProductId,
                                OI.amount AS Amount,
                                OI.product_name AS Name,
                                OI.price As Price,
                                P.product_image as Image
                            FROM orders O
                            INNER JOIN orderitems OI ON O.order_id = OI.order_id
                            INNER JOIN customers C on C.customer_id = O.customer_id
                            INNER JOIN orderstatus OC on OC.order_status_id = O.order_status_id
                            INNER JOIN products P ON P.product_Id = OI.product_id";




            var lookup = new Dictionary<long, OrderDTO>();
            connection.Query<OrderDTO, ProductDTO, OrderDTO>(query, (o, l) => {
                OrderDTO order;
                if (!lookup.TryGetValue(o.OrderId, out order))
                    lookup.Add(o.OrderId, order = o);
                if (order.ProductList == null)
                    order.ProductList = new List<ProductDTO>();
                order.ProductList.Add(l);
                return order;
            }).AsQueryable();
            response = lookup.Values.ToList();

            return response;
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
