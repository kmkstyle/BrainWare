using System.Collections.Generic;
using Web.Models;
using Web.Services;

namespace Web.Infrastructure
{
    /// <summary>
    /// Order helper class
    /// </summary>
    public class OrderHelper
    {
        /// <summary>
        /// Order service
        /// </summary>
        OrderService OrderService => new OrderService();

        /// <summary>
        /// Get orders and order products for a specified company Id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns>List of orders</returns>
        public List<Order> GetOrdersAndOrderProductsForCompany(int companyId)
        {
            var orders = OrderService.GetOrdersForCompany(companyId);
            var orderProducts = OrderService.GetOrderProductsForCompany(companyId);

            foreach (var order in orders)
            {
                if (orderProducts.ContainsKey(order.OrderId))
                {
                    foreach (var orderproduct in orderProducts[order.OrderId])
                    {
                        order.OrderProducts.Add(orderproduct);
                        order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                    }
                }
            }

            return orders;
        }
    }
}