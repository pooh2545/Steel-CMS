using System.ComponentModel.DataAnnotations;

public class Article
{
    public int Id { get; set; }

    [Required(ErrorMessage = "กรุณาระบุหัวข้อบทความ")]
    public string Title { get; set; }

    [Required(ErrorMessage = "กรุณาระบุเนื้อหาบทความ")]
    public string Content { get; set; }

    public string ImageUrl { get; set; }

    public bool IsPublished { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? PublishedAt { get; set; }

    public string Author { get; set; }
}