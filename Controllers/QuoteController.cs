using Microsoft.AspNetCore.Mvc;
using api_freshclean.DTOs;
using api_freshclean.Services;

namespace api_freshclean.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuoteController : ControllerBase
{
    private readonly IQuoteService _quoteService;

    public QuoteController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }

    // GET: api/quote
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var quotes = await _quoteService.GetAllAsync();
        return Ok(quotes);
    }

    // GET: api/quote/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var quote = await _quoteService.GetByIdAsync(id);
        if (quote == null)
            return NotFound(new { message = "Quote not found." });

        return Ok(quote);
    }

    // POST: api/quote
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuoteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var quote = await _quoteService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = quote!.Id },
            quote
        );
    }

    // PUT: api/quote/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateQuoteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existing = await _quoteService.UpdateAsync(id, dto);
        if (existing == null)
            return NotFound(new { message = "Quote not found." });

        return Ok(existing);
    }

    // DELETE: api/quote/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _quoteService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = "Quote not found." });

        return NoContent();
    }
}
