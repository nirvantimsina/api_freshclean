namespace api_freshclean.Models;

public class Quote
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public required int Phone { get; set; }
    public string? Email { get; set; }
    public string? Service { get; set; }
    public string? Frequency { get; set; }
    public string? Message { get; set; }
}