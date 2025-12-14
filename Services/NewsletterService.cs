using api_freshclean.DTOs;
using api_freshclean.Models;
using api_freshclean.Repositories;

namespace api_freshclean.Services;

public class NewsletterService : INewsletterService
{
    private readonly INewsletterRepository _repository;
    public NewsletterService(INewsletterRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Newsletter>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Newsletter?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<Newsletter?> CreateAsync(CreateNewsletterDto dto)
    {
        var newsletter = new Newsletter
        {
            Email = dto.Email
        };

        return _repository.CreateAsync(newsletter);
    }

    public async Task<Newsletter?> UpdateAsync(int id, CreateNewsletterDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return null;

        existing.Email = dto.Email;

        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}