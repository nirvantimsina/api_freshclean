using System.ComponentModel.DataAnnotations;

namespace api_freshclean.DTOs;

public class CreateNewsletterDto
{
    [Required(ErrorMessage = "Email is required!" )]
    [EmailAddress]
    public string? Email { get; set; }
}