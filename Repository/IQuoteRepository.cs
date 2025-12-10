using api_freshclean.Models;

namespace api_freshclean.Repositories;

public interface IQuoteRepository
{
    Task<List<Quote>> GetAllAsync();
    Task<Quote?> GetByIdAsync(int id);
    Task<Quote?> CreateAsync(Quote quote);
    Task<Quote?> UpdateAsync(Quote quote);
    Task<bool> DeleteAsync(int id);
}