using System.ComponentModel.DataAnnotations;

namespace api_freshclean.DTOs;

public class CreateContactDto
{
    [MaxLength(50)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required!")]
    [MaxLength(70)]
    [EmailAddress(ErrorMessage = "Invalid Email Format!")]
    public string? Email { get; set; }

    [MaxLength(150)]
    public string? Subject { get; set; }
    
    [MaxLength(500)]
    public string? Message { get; set; }
}