using api_freshclean.Data;
using api_freshclean.Models;
using Microsoft.EntityFrameworkCore;

namespace api_freshclean.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;
    public ContactRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> GetAllAsync()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<Contact?> CreateAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact?> UpdateAsync(Contact contact)
    {
        var existing = await _context.Contacts.FindAsync(contact.Id);
        if (existing == null) return null;

        existing.Name = contact.Name;
        existing.Email = contact.Email;
        existing.Subject = contact.Subject;
        existing.Message = contact.Message;

        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync();
        if (contact == null) return false;

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return true;
    }
}