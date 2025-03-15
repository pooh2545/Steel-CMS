using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelCMS.Client.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly SteelDbContext _context;

    public CartController(SteelDbContext context)
    {
        _context = context;
    }

    // ✅ 1. ดึงตะกร้าสินค้าตาม Customer ID
    [HttpGet("{customerId}")]
    public async Task<ActionResult<IEnumerable<Cart>>> GetCartByCustomer(int customerId)
    {
        var cartItems = await _context.cart
            .Where(c => c.customer_id == customerId)
            .Include(c => c.SteelProduct) // ดึงข้อมูลสินค้าด้วย
            .ThenInclude(p => p.SteelType) // ดึงข้อมูลประเภทเหล็ก
            .ToListAsync();

        if (cartItems == null || cartItems.Count == 0)
            return NotFound(new { message = "Cart is empty" });

        return Ok(cartItems);
    }

    // ✅ 2. เพิ่มสินค้าเข้าตะกร้า
    [HttpPost]
    public async Task<ActionResult<Cart>> AddToCart(cart cartItem)
    {
        if (cartItem == null)
            return BadRequest("Invalid cart item");

        var existingItem = await _context.cart
            .FirstOrDefaultAsync(c => c.customer_id == cartItem.customer_id && c.steel_id == cartItem.steel_id);

        if (existingItem != null)
        {
            existingItem.amount += cartItem.amount;
        }
        else
        {
            _context.cart.Add(cartItem);
        }

        await _context.SaveChangesAsync();
        return Ok(cartItem);
    }

    // ✅ 3. ลบสินค้าจากตะกร้า
    [HttpDelete("{rowId}")]
    public async Task<IActionResult> RemoveFromCart(int rowId)
    {
        var cartItem = await _context.cart.FindAsync(rowId);
        if (cartItem == null)
            return NotFound(new { message = "Item not found" });

        _context.cart.Remove(cartItem);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Item removed from cart" });
    }
}
