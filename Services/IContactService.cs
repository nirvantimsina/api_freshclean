using api_freshclean.DTOs;
using api_freshclean.Models;

namespace api_freshclean.Services;

public interface IContactService
{
    Task<List<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact?> CreateAsync(CreateContactDto dto);
    Task<Contact?> UpdateAsync(int id, CreateContactDto dto);
    Task<bool> DeleteAsync(int id);
}