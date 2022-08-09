using Moq;
using WarehouseManagementSystem.Infrastructure;
using WarehouseManagementSystem.Web.Controllers;
using WarehouseManagementSystem.Web.Models;

namespace WarehouseManagementSystem.Web.Tests;

[TestClass]
public class OrderControllerTests
{
    [TestMethod]
    public void CanCreateOrderWithCorrectModel()
    {
        // ARRANGE
        var orderRepository = new Mock<IRepository<Order>>();
        var itemRepository = new Mock<IRepository<Item>>();
        var shippingProviderRepository =
            new Mock<IRepository<ShippingProvider>>();

        // Return a fake ShippingProvider
        // when All() is callled
        shippingProviderRepository.Setup(
            repository => repository.All()
        ).Returns(new[] { new ShippingProvider() });

        var orderController = new OrderController(
            orderRepository.Object,
            shippingProviderRepository.Object,
            itemRepository.Object
        );

        var createOrderModel = new CreateOrderModel
        {
            Customer = new()
            {
                Name = "Filip Ekberg",
                Address = "Kungsbacka",
                PostalCode = "43494",
                Country = "Sweden",
                PhoneNumber = "+46 1111 111 11"
            },
            LineItems = new[]
            {
                new LineItemModel
                {
                    ItemId = Guid.NewGuid(),
                    Quantity = 100
                }
            }
        };

        // ACT
        orderController.Create(createOrderModel);

        // ASSERT
        orderRepository.Verify(
            repository => repository.Add(It.IsAny<Order>()),
            Times.AtMostOnce()
        );
    }
}