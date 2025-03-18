using System.ComponentModel.DataAnnotations;

public class Portfolio
{
    public int Id { get; set; }

    [Required(ErrorMessage = "กรุณาระบุชื่อผลงาน")]
    public string Title { get; set; }

    [Required(ErrorMessage = "กรุณาระบุคำอธิบายผลงาน")]
    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public string ClientName { get; set; }

    public DateTime CompletionDate { get; set; }

    public bool IsDisplayed { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string CreatedBy { get; set; }
}