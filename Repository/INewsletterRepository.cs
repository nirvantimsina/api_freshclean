using api_freshclean.Models;

namespace api_freshclean.Repositories;

public interface INewsletterRepository
{
    Task<List<Newsletter>> GetAllAsync();
    Task<Newsletter?> GetByIdAsync(int id);
    Task<Newsletter?> CreateAsync(Newsletter newsletter);
    Task<Newsletter?> UpdateAsync(Newsletter newsletter);
    Task<bool> DeleteAsync(int id);
}