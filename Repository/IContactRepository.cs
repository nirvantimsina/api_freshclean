using api_freshclean.Models;

namespace api_freshclean.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact?> CreateAsync(Contact contact);
    Task<Contact?> UpdateAsync(Contact contact);
    Task<bool> DeleteAsync(int id);
}