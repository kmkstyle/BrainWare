using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Infrastructure;
using Web.Models;

namespace Tests.Infrastructure
{
    [TestClass]
    public class OrderHelperClassTest
    {
        [TestMethod]
        public void GetOrdersAndOrderProductsForCompany_Returns_NoOrders()
        {
            // Arrange
            OrderHelper orderHelper = new OrderHelper();
            var companyId = 0;
            var expectedResult = 0;

            // Act
            var orders = orderHelper.GetOrdersAndOrderProductsForCompany(companyId);

            // Assert
            Assert.IsNotNull(orders);
            Assert.AreEqual(expectedResult, orders.Count);
        }

        [TestMethod]
        public void GetOrdersAndOrderProductsForCompany_Returns_OrderList()
        {
            // Arrange
            OrderHelper orderHelper = new OrderHelper();
            var companyId = -1;

            // Act
            var orders = orderHelper.GetOrdersAndOrderProductsForCompany(companyId);

            // Assert
            Assert.IsInstanceOfType(orders, typeof(List<Order>));
        }
    }
}
