using System.ComponentModel.DataAnnotations;

namespace Library.BLL.DTOs;

public class BookDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    [Range(1, 2100, ErrorMessage = "Published year must be valid")]
    public int PublishedYear { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    public int AuthorId { get; set; }
}
