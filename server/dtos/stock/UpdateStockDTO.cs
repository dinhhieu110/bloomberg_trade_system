using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.dtos.stock
{
    public class UpdateStockDTO
    {
    [Required]
    [MaxLength(10, ErrorMessage = "Symbol must be at most 10 characters long")]
    public string Symbol { get; set; } = string.Empty;
    [Required]
    [MaxLength(10, ErrorMessage = "Company Name must be at most 10 characters long")]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(1,1000000000, ErrorMessage = "Price must be between 1 and 1000000000")]
    public decimal Purchase { get; set; }
    [Required]
    [Range(0.001, 100)]
    public decimal LastDiv { get; set; }
    [Required]
    [MaxLength(10, ErrorMessage = "Industry must be at most 10 characters long")]
    public string Industry { get; set; } = string.Empty;
    [Required]
    [Range(1, 500000000, ErrorMessage = "Market Cap must be between 1 and 50000000")]
    public long MarketCap { get; set; }

    }
}
