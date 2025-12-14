using api_freshclean.DTOs;
using api_freshclean.Models;
using api_freshclean.Repositories;

namespace api_freshclean.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Contact>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Contact?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<Contact?> CreateAsync(CreateContactDto dto)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            Email = dto.Email,
            Subject = dto.Subject,
            Message = dto.Message
        };
        return _repository.CreateAsync(contact);
    }

    public async Task<Contact?> UpdateAsync(int id, CreateContactDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return null;

        existing.Name = dto.Name;
        existing.Email = dto.Email;
        existing.Subject = dto.Subject;
        existing.Message = dto.Message;

        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}