using System.Collections.Generic;

namespace Web.Models
{
    /// <summary>
    /// Order class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Order total
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Order products
        /// </summary>
        public List<OrderProduct> OrderProducts { get; set; }
    }
}