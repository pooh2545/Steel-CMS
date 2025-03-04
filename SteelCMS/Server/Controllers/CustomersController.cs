using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelCMS.Shared;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly SteelDbContext _context;

    public CustomersController(SteelDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CustomerRegistrationModel model)
    {
        if (await _context.customers.AnyAsync(u => u.email == model.Email))
        {
            return BadRequest("อีเมลนี้ถูกใช้ไปแล้ว");
        }

        var customers = new customers
        {
            fullname = model.FullName,
            email = model.Email,
            password = BCrypt.Net.BCrypt.HashPassword(model.Password), // เข้ารหัสรหัสผ่าน
            tel = model.Tel
        };

        _context.customers.Add(customers);
        await _context.SaveChangesAsync();

        return Ok("สมัครสมาชิกสำเร็จ");
    }
}

public class CustomerRegistrationModel
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Tel { get; set; }
}
