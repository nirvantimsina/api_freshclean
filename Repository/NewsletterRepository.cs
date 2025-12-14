using api_freshclean.Models;
using api_freshclean.Data;
using Microsoft.EntityFrameworkCore;

namespace api_freshclean.Repositories;

public class NewsletterRepository : INewsletterRepository
{
    public readonly AppDbContext _context;
    public NewsletterRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Newsletter>> GetAllAsync()
    {
        return await _context.Newsletters.ToListAsync();
    }

    public async Task<Newsletter?> GetByIdAsync(int id)
    {
        return await _context.Newsletters.FindAsync(id);
    }

    public async Task<Newsletter?> CreateAsync(Newsletter newsletter)
    {
        _context.Newsletters.Add(newsletter);
        await _context.SaveChangesAsync();
        return newsletter;
    }

    public async Task<Newsletter?> UpdateAsync(Newsletter newsletter)
    {
        var existing = await _context.Newsletters.FindAsync(newsletter.Id);
        if (existing == null) return null;

        existing.Email = newsletter.Email;

        await _context.SaveChangesAsync();
        return newsletter;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var newsletter = await _context.Newsletters.FindAsync();
        if (newsletter == null) return false;

        _context.Newsletters.Remove(newsletter);
        await _context.SaveChangesAsync();
        return true;
    }
}