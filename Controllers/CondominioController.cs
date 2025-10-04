using Microsoft.AspNetCore.Mvc;

namespace Condominium.Controllers;
{
[ApiController]
[Route("api/[controller]")]
public class CondominioController : ControllerBase
{
    private readonly CondoContext _db;

    // GET: api/condominios?search=Alpha&page=1&pageSize=20
    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        var query = _db.condominio.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(c => c.nombre.Contains(search) || c.direccion.Contains(search));

        var total = await query.CountAsync();
        var items = await query.OrderBy(c => c.id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return Ok(new { total, page, pageSize, items });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(string id)
    {
        var entity = await _db.condominio.FindAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CondominioCreateDto dto)
    {
        var entity = new Models.condominio{nombre = dto.nombre,direccion = dto.direccion,image_condominio = dto.image_condominio};

        _db.condominio.Add(entity);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string id, [FromBody] CondominioUpdateDto dto)
    {
        var entity = await _db.condominio.FindAsync(id);
        if (entity is null) return NotFound();

        entity.nombre = dto.nombre;
        entity.direccion = dto.direccion;
        entity.image_condominio = dto.image_condominio;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var entity = await _db.condominio.FindAsync(id);
        if (entity is null) return NotFound();
        _db.condominio.Remove(entity);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
}
