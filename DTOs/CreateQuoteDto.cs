using System.ComponentModel.DataAnnotations;

namespace api_freshclean.DTOs;

public class CreateQuoteDto
{
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone]
    public int Phone { get; set; }

    [EmailAddress]
    [MaxLength(150)]
    public string? Email { get; set; }

    public string? Service { get; set; }

    public string? Frequency { get; set; }
    
    [MaxLength(500)]
    public string? Message { get; set; }
}