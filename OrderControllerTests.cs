using Microsoft.AspNetCore.Mvc;
using OrderMircroservice.Controllers;
using Xunit;

public class OrderControllerTests
{
    private readonly OrderController _controller;

    public OrderControllerTests()
    {
        _controller = new OrderController();
    }

    [Fact]
    public void Get_ReturnsExpectedMessage()
    {
        // Act
        var result = _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal("Hello from OrderController! And by the way this works too! And is changed now!", okResult.Value);
    }
}
