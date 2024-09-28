using HeroesAPI.Collections;
using HeroesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Controllers;

[ApiController]
[Route("api[controller]")]
public class HeroisController : ControllerBase
{
    private readonly IHeroisRepository _repo;

    public HeroisController(IHeroisRepository repository)
    {
        _repo = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var herois = await _repo.GetAllAsync();
        return Ok(herois);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var herois = await _repo.GetByIdAsync(id);
        if (herois == null)
            return NotFound("Herói não encontrado");
        return Ok(herois);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Herois herois)
    {
        await _repo.CreateAsync(herois);
        return CreatedAtAction(nameof(Get), new { id = herois.Id }, herois);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Herois herois)
    {
        var hero = await _repo.GetByIdAsync(herois.Id);
        if (hero == null)
            return NotFound("Herói não encontrado");

        await _repo.UpdateAsync(herois);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var hero = await _repo.GetByIdAsync(id);
        if (hero == null)
            return NotFound("Herói não encontrado");
            await _repo.DeleteAsync(id);
            return NoContent();
    }
}
