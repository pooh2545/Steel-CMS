using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "กรุณาระบุชื่อผู้ใช้")]
    [StringLength(50, ErrorMessage = "ชื่อผู้ใช้ต้องมีความยาวไม่เกิน 50 ตัวอักษร")]
    public string Username { get; set; }

    [Required(ErrorMessage = "กรุณาระบุรหัสผ่าน")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร และไม่เกิน 100 ตัวอักษร")]
    public string Password { get; set; }

    [Required(ErrorMessage = "กรุณาระบุชื่อจริง")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "กรุณาระบุนามสกุล")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "กรุณาระบุอีเมล")]
    [EmailAddress(ErrorMessage = "รูปแบบอีเมลไม่ถูกต้อง")]
    public string Email { get; set; }

    public string Role { get; set; } // Admin, Employee

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? LastLogin { get; set; }
}