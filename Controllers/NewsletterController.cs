using api_freshclean.DTOs;
using api_freshclean.Data;
using api_freshclean.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_freshclean.Repositories;
using api_freshclean.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api_freshclean.Controllers;

[ApiController]
[Route("api/[controller]")]

public class NewslettterController : ControllerBase
{
    private readonly INewsletterService _newsletterService;

    public NewslettterController(INewsletterService newsletterService)
    {
        _newsletterService = newsletterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var newsletter = await _newsletterService.GetAllAsync();
        return Ok(newsletter);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var newsletter = await _newsletterService.GetByIdAsync(id);
        if (newsletter == null) return NotFound(new { message = "Newsletter not found" });

        return Ok(newsletter);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNewsletterDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var newsletter = await _newsletterService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = newsletter!.Id }, newsletter);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateNewsletterDto dto, int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existing = await _newsletterService.UpdateAsync(id, dto);
        if (existing == null) return NotFound(new { message = "Email not found." });

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _newsletterService.DeleteAsync(id);
        if (!deleted) return NotFound(new { message = "newsletter not found." });

        return NoContent();
    }
}