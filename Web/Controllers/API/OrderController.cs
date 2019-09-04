using System.Collections.Generic;
using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Models;

    /// <summary>
    /// Order controller class
    /// </summary>
    public class OrderController : ApiController
    {
        /// <summary>
        /// Order helper
        /// </summary>
        public OrderHelper OrderHelper => new OrderHelper();    
  
        /// <summary>
        /// Get orders for a specified company id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns>Collection of orders</returns>
        [HttpGet]
        public IEnumerable<Order> GetOrders(int companyId = 1)
        {
            return OrderHelper.GetOrdersAndOrderProductsForCompany(companyId);
        }
    }
}
