using ChessClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessClub.Controllers;

public class PlayersController : Controller
{
    private static readonly List<Player> Players =
    [
        new Player { Id = 1, Name = "Magnus", Email = "magnus@example.com", Rating = 2830, Country = "Norway" },
        new Player { Id = 2, Name = "Hikaru", Email = "hikaru@example.com", Rating = 2800, Country = "USA" },
        new Player { Id = 3, Name = "Arjun", Email = "arjun@example.com", Rating = 2770, Country = "India" }
    ];

    public IActionResult Index(string? search)
    {
        var players = string.IsNullOrWhiteSpace(search)
            ? Players
            : Players.Where(p =>
                p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                p.Country.Contains(search, StringComparison.OrdinalIgnoreCase))
              .ToList();

        return View(players);
    }

    public IActionResult Details(int id)
    {
        var player = Players.FirstOrDefault(p => p.Id == id);

        if (player == null)
            return NotFound();

        return View(player);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Player player)
    {
        if (!ModelState.IsValid)
            return View(player);

        player.Id = Players.Count == 0 ? 1 : Players.Max(p => p.Id) + 1;
        Players.Add(player);

        return RedirectToAction(nameof(Index));
    }
}
