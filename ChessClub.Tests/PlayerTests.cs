using ChessClub.Models;
using Xunit;

namespace ChessClub.Tests;

public class PlayerTests
{
    [Fact]
    public void Player_CanBeCreated()
    {
        var player = new Player
        {
            Id = 1,
            Name = "Test Player",
            Email = "test@example.com",
            Rating = 1500,
            Country = "India"
        };

        Assert.Equal("Test Player", player.Name);
        Assert.Equal(1500, player.Rating);
    }
}
