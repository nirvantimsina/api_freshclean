using api_freshclean.DTOs;
using api_freshclean.Models;
using api_freshclean.Repositories;

namespace api_freshclean.Services;

public class QuoteService : IQuoteService
{
    private readonly IQuoteRepository _repository;

    public QuoteService(IQuoteRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Quote>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Quote?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<Quote?> CreateAsync(CreateQuoteDto dto)
    {
        var quote = new Quote
        {
            Name = dto.Name,
            Phone = dto.Phone,
            Email = dto.Email,
            Service = dto.Service,
            Frequency = dto.Frequency,
            Message = dto.Message
        };

        return _repository.CreateAsync(quote);
    }

    public async Task<Quote?> UpdateAsync(int id, CreateQuoteDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return null;

        existing.Name = dto.Name;
        existing.Phone = dto.Phone;
        existing.Email = dto.Email;
        existing.Service = dto.Service;
        existing.Frequency = dto.Frequency;
        existing.Message = dto.Message;

        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
}