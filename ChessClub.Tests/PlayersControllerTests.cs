using ChessClub.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ChessClub.Tests;

public class PlayersControllerTests
{
    [Fact]
    public void Index_ReturnsView()
    {
        var controller = new PlayersController();

        var result = controller.Index(null);

        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Details_InvalidId_ReturnsNotFound()
    {
        var controller = new PlayersController();

        var result = controller.Details(99999);

        Assert.IsType<NotFoundResult>(result);
    }
}
