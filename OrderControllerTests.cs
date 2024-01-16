using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderMicroservice.Data.Interfaces;
using OrderMircroservice.Controllers;
using OrderMicroservice.Models;
using System.Collections.Generic;
using Xunit;

public class OrderControllerTests
{
    private readonly OrderController _controller;
    private readonly Mock<IOrderRepo> _mockRepository;

    public OrderControllerTests()
    {
        _mockRepository = new Mock<IOrderRepo>();
        _controller = new OrderController(_mockRepository.Object);

        _mockRepository.Setup(repo => repo.GetAllOrders())
                       .Returns(GetTestOrders());
    }

    private List<Order> GetTestOrders()
    {
        var orders = new List<Order>
        {
            new Order() { /* Initialize properties */ },
            new Order() { /* Initialize properties */ }

        };

        return orders;
    }

    [Fact]
    public void GetAllOrders_ReturnsAllOrders()
    {
        // Act
        var result = _controller.GetAllOrders();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Order>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedOrders = Assert.IsType<List<Order>>(okResult.Value);
        Assert.Equal(2, returnedOrders.Count); 
    }

}
