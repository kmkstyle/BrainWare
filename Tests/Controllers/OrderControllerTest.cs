using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;
using Web.Models;

namespace Tests.Controllers
{
    [TestClass]
    public class OrderControllerClassTest
    {
        [TestMethod]
        public void GetOrdersForCompany_Returns_NoOrders()
        {
            // Arrange
            OrderController orderController = new OrderController();
            var companyId = 0;
            var expectedResult = 0;

            // Act
            var orders = orderController.GetOrders(companyId) as List<Order>;

            // Assert
            Assert.IsNotNull(orders);
            Assert.AreEqual(expectedResult, orders.Count);
        }

        [TestMethod]
        public void GetOrdersForCompany_Returns_OrderList()
        {
            // Arrange
            OrderController orderController = new OrderController();
            var companyId = -1;

            // Act
            var orders = orderController.GetOrders(companyId) as List<Order>;

            // Assert
            Assert.IsInstanceOfType(orders, typeof(List<Order>));
        }

        [TestMethod]
        public void GetOrdersForNoCompany_Returns_OrderList()
        {
            // Arrange
            OrderController orderController = new OrderController();

            // Act
            var orders = orderController.GetOrders() as List<Order>;

            // Assert
            Assert.IsInstanceOfType(orders, typeof(List<Order>));
        }
    }
}
