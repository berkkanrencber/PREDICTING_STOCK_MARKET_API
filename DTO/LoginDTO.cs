using System.ComponentModel.DataAnnotations;

namespace PREDICTING_STOCK_MARKET_API.DTO;

public class LoginDTO{

    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}