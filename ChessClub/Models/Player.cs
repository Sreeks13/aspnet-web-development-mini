using System.ComponentModel.DataAnnotations;

namespace ChessClub.Models;

public class Player
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Range(0, 3000)]
    public int Rating { get; set; }

    public string Country { get; set; } = string.Empty;
}
