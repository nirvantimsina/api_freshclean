using api_freshclean.DTOs;
using api_freshclean.Models;

namespace api_freshclean.Services;

public interface INewsletterService
{
    Task<List<Newsletter>> GetAllAsync();
    Task<Newsletter?> GetByIdAsync(int id);
    Task<Newsletter?> CreateAsync(CreateNewsletterDto dto);
    Task<Newsletter?> UpdateAsync(int id, CreateNewsletterDto dto);
    Task<bool> DeleteAsync(int id);
}