using api_freshclean.DTOs;
using api_freshclean.Models;

namespace api_freshclean.Services;

public interface IQuoteService
{
    Task<List<Quote>> GetAllAsync();
    Task<Quote?> GetByIdAsync(int id);
    Task<Quote?> CreateAsync(CreateQuoteDto dto);
    Task<Quote?> UpdateAsync(int id, CreateQuoteDto dto);
    Task<bool> DeleteAsync(int id);
}