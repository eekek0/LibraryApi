using System.ComponentModel.DataAnnotations;

namespace Library.BLL.DTOs;

public class AuthorDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name length can't exceed 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of birth is required")]
    public DateTime DateOfBirth { get; set; }
}
