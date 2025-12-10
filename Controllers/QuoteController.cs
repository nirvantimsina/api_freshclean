using Microsoft.AspNetCore.Mvc;
using api_freshclean.Data;
using api_freshclean.DTOs;
using api_freshclean.Models;
using Microsoft.EntityFrameworkCore;

namespace api_freshclean.Controllers;

[ApiController]
[Route("api/[controller]")]

public class QuoteController : ControllerBase
{
    private readonly AppDbContext _context;

    public QuoteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var quotes = await _context.Quotes.ToListAsync();
        return Ok(quotes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        if (quote == null) return NotFound(new { message = "Quote Not Found!" });

        return Ok(quote);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateQuoteDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var quote = new Quote
        {
            Name = dto.Name,
            Phone = dto.Phone,
            Email = dto.Email,
            Service = dto.Service,
            Frequency = dto.Frequency,
            Message = dto.Message
        };

        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = quote.Id }, quote);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateQuoteDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var quote = await _context.Quotes.FindAsync(id);
        if (quote == null) return NotFound(new { message = " Quote Not Found!" });

        quote.Name = dto.Name;
        quote.Phone = dto.Phone;
        quote.Email = dto.Email;
        quote.Service = dto.Service;
        quote.Frequency = dto.Frequency;
        quote.Message = dto.Message;


        await _context.SaveChangesAsync();
        return Ok(quote);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        if (quote == null) return NotFound( new {message = "Quote Not Found"});

        _context.Remove(quote);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}