using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

[Route("api/[controller]")]
[ApiController]
public class SteelProductController : ControllerBase
{
    private readonly SteelDbContext _context;

    public SteelProductController(SteelDbContext context)
    {
        _context = context;
    }

    // GET: api/SteelProduct
    [HttpGet]
    public async Task<ActionResult<IEnumerable<steelproduct>>> GetSteelProducts(
        [FromQuery] int? steeltype_id,
        [FromQuery] string? steel_name,
        [FromQuery] decimal? min_price,
        [FromQuery] decimal? max_price,
        [FromQuery] string? sort_by,
        [FromQuery] string? order)
    {
        var query = _context.steelproducts.Include(s => s.SteelType).AsQueryable();

        if (steeltype_id.HasValue)
        {
            query = query.Where(s => s.steeltype_id == steeltype_id.Value);
        }

        if (!string.IsNullOrEmpty(steel_name))
        {
            query = query.Where(s => s.steel_name.Contains(steel_name));
        }

        if (min_price.HasValue)
        {
            query = query.Where(s => s.steel_price >= min_price.Value);
        }

        if (max_price.HasValue)
        {
            query = query.Where(s => s.steel_price <= max_price.Value);
        }

        if (!string.IsNullOrEmpty(sort_by))
        {
            bool isDescending = order?.ToLower() == "desc";
            query = sort_by.ToLower() switch
            {
                "name" => isDescending ? query.OrderByDescending(s => s.steel_name) : query.OrderBy(s => s.steel_name),
                "price" => isDescending ? query.OrderByDescending(s => s.steel_price) : query.OrderBy(s => s.steel_price),
                "type" => isDescending ? query.OrderByDescending(s => s.SteelType.steeltype_name) : query.OrderBy(s => s.SteelType.steeltype_name),
                _ => query
            };
        }

        return await query.ToListAsync();
    }

    // GET: api/SteelProduct/5
    [HttpGet("{id}")]
    public async Task<ActionResult<steelproduct>> GetSteelProduct(int id)
    {
        var product = await _context.steelproducts.Include(s => s.SteelType).FirstOrDefaultAsync(p => p.steel_id == id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    // POST: api/SteelProduct
    [HttpPost]
    public async Task<ActionResult<steelproduct>> PostSteelProduct(steelproduct product)
    {
        _context.steelproducts.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSteelProduct), new { id = product.steel_id }, product);
    }

    // PUT: api/SteelProduct/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSteelProduct(int id, steelproduct product)
    {
        if (id != product.steel_id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.steelproducts.Any(e => e.steel_id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/SteelProduct/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSteelProduct(int id)
    {
        var product = await _context.steelproducts.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.steelproducts.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
