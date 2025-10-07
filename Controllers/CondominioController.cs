using Microsoft.AspNetCore.Mvc;
using Condominium.Data;
using Condominium.Dtos;
using Microsoft.EntityFrameworkCore;
using Condominium.Data.Models;

namespace Condominium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CondominioController : ControllerBase
{
    private readonly CondoContext _db;

    // GET: api/condominio?search=Alpha&page=1&pageSize=20
    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = _db.Condominios.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(Condominio)(c => c.Nombre.Contains(search) || c.Direccion.Contains(search));

        var total = await query.CountAsync();
        var items = await query.OrderBy(c => c.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return Ok(new { total, page, pageSize, items });
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult> GetById(string Id)
    {
        var entity = await _db.Condominios.FindAsync(Id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CondominioCreateDto dto)
    {
        var entity = new Condominio { Nombre = dto.Nombre, Direccion = dto.Direccion, ImageCondominio = dto.ImageCondominio };
        _db.Condominios.Add(entity);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { Id = entity.Id }, entity);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> Update(string Id, [FromBody] CondominioUpdateDto dto)
    {
        var entity = await _db.Condominios.FindAsync(Id);
        if (entity is null) return NotFound();

        entity.Nombre = dto.Nombre;
        entity.Direccion = dto.Direccion;
        entity.ImageCondominio = dto.ImageCondominio;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete(string Id)
    {
        var entity = await _db.Condominios.FindAsync(Id);
        if (entity is null) return NotFound();
        _db.Condominios.Remove(entity);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
