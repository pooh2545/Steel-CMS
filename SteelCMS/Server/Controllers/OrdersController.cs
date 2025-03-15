using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly SteelDbContext _context;

    public OrdersController(SteelDbContext context)
    {
        _context = context;
    }

    // ✅ Get All Orders พร้อม Customer และ Items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<order>>> GetAllOrders()
    {
        var orders = await _context.orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.SteelProduct)
            .ToListAsync();

        if (!orders.Any())
        {
            return NotFound("No orders found.");
        }

        return Ok(orders);
    }

    // ✅ Get Order By ID
    [HttpGet("{id}")]
    public async Task<ActionResult<order>> GetOrderById(int id)
    {
        var order = await _context.orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.SteelProduct)
            .FirstOrDefaultAsync(o => o.order_id == id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    // ✅ Get Orders By Customer ID
    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<order>>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _context.orders
            .Where(o => o.customer_id == customerId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.SteelProduct)
            .ToListAsync();

        if (!orders.Any())
        {
            return NotFound($"No orders found for customer ID {customerId}.");
        }

        return Ok(orders);
    }

    // ✅ Create Order
    [HttpPost]
    public async Task<ActionResult<order>> CreateOrder(order newOrder)
    {
        if (newOrder == null)
        {
            return BadRequest("Invalid order data.");
        }

        _context.orders.Add(newOrder);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.order_id }, newOrder);
    }

    // ✅ Update Order
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, order updatedOrder)
    {
        if (id != updatedOrder.order_id)
        {
            return BadRequest("Order ID mismatch.");
        }

        var existingOrder = await _context.orders.FindAsync(id);
        if (existingOrder == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        // อัปเดตค่าต่างๆ ของ Order
        existingOrder.customer_id = updatedOrder.customer_id;
        existingOrder.address_id = updatedOrder.address_id;
        existingOrder.order_total = updatedOrder.order_total;
        existingOrder.slip_path = updatedOrder.slip_path;
        existingOrder.status_id = updatedOrder.status_id;
        existingOrder.tracking_number = updatedOrder.tracking_number;
        existingOrder.status = updatedOrder.status;
        existingOrder.confirm_at = updatedOrder.confirm_at;
        existingOrder.pay_at = updatedOrder.pay_at;
        existingOrder.verify_at = updatedOrder.verify_at;
        existingOrder.transit_at = updatedOrder.transit_at;
        existingOrder.delivery_at = updatedOrder.delivery_at;
        existingOrder.prepare_at = updatedOrder.prepare_at;

        _context.Entry(existingOrder).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // ✅ Delete Order
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.orders.FindAsync(id);
        if (order == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        _context.orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
