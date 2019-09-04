namespace Web.Models
{
    /// <summary>
    /// Order product class
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Order Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
    }
}