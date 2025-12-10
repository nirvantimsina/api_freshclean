using api_freshclean.Data;
using api_freshclean.DTOs;
using api_freshclean.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api_freshclean.Repositories;

public class QuoteRepository : IQuoteRepository
{
    private readonly AppDbContext _context;
    public QuoteRepository(AppDbContext context)
    {
        _context = context;
    }

    // get
    public async Task<List<Quote>> GetAllAsync()
    {
        return await _context.Quotes.ToListAsync();
    }

    // get by id
    public async Task<Quote?> GetByIdAsync(int id)
    {
        return await _context.Quotes.FindAsync(id);
    }

    // post
    public async Task<Quote?> CreateAsync(Quote quote)
    {
        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();
        return quote;
    }
    

    // put
    public async Task<Quote?> UpdateAsync(Quote quote)
    {
        var existing = await _context.Quotes.FindAsync(quote.Id);
        if (existing == null) return null;

        existing.Name = quote.Name;
        existing.Phone = quote.Phone;
        existing.Email = quote.Email;
        existing.Service = quote.Service;
        existing.Frequency = quote.Frequency;
        existing.Message = quote.Message;

        await _context.SaveChangesAsync();
        return quote;
    }

    // delete
    public async Task<bool> DeleteAsync(int id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        if (quote == null) return false;

        _context.Quotes.Remove(quote);
        await _context.SaveChangesAsync();
        return true;
    }
}