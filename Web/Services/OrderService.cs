using System.Collections.Generic;
using System.Data;

namespace Web.Services
{
    using Models;

    /// <summary>
    /// Order service class
    /// </summary>
    public class OrderService
    {
        /// <summary>
        /// Database
        /// </summary>
        public Database Database => new SqlDatabase();
               
        /// <summary>
        /// Get orders for a specified company Id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns>List of orders</returns>
        public List<Order> GetOrdersForCompany(int companyId)
        {
            var orders = new List<Order>();

            using (IDbConnection connection = Database.CreateOpenConnection())
            {
                // Get the orders
                var sql = $"SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id where c.company_id={companyId}";
                using (IDbCommand command = Database.CreateCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var dataRecord = (IDataRecord)reader;
                        orders.Add(new Order()
                        {
                            CompanyName = dataRecord.GetString(0),
                            Description = dataRecord.GetString(1),
                            OrderId = dataRecord.GetInt32(2),
                            OrderProducts = new List<OrderProduct>()
                        });
                    }
                }
            }
            
            return orders;
        }

        /// <summary>
        /// Get order products for a specified company Id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns>Dictionary of order products</returns>
        public Dictionary<int, List<OrderProduct>> GetOrderProductsForCompany(int companyId)
        {
            var orderProducts = new Dictionary<int, List<OrderProduct>>();

            using (IDbConnection connection = Database.CreateOpenConnection())
            {
                var sql = $"SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id INNER JOIN [order] o on op.order_id=o.order_id where o.company_id={companyId}";
                using (IDbCommand command = Database.CreateCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var dataRecord = (IDataRecord)reader;
                        var orderProduct = new OrderProduct()
                        {
                            OrderId = dataRecord.GetInt32(1),
                            ProductId = dataRecord.GetInt32(2),
                            Price = dataRecord.GetDecimal(0),
                            Quantity = dataRecord.GetInt32(3),
                            Product = new Product()
                            {
                                Name = dataRecord.GetString(4),
                                Price = dataRecord.GetDecimal(5)
                            }
                        };
                        if (!orderProducts.ContainsKey(orderProduct.OrderId))
                        {
                            orderProducts.Add(orderProduct.OrderId, new List<OrderProduct>() { orderProduct });
                        }
                        else
                        {
                            orderProducts[orderProduct.OrderId].Add(orderProduct);
                        }
                    }
                }
            }

            return orderProducts;
        }
    }
}