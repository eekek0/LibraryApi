using Microsoft.AspNetCore.Mvc;
using Library.BLL.DTOs;
using Library.BLL.Services;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var book = _service.GetById(id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public IActionResult Create(BookDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            return BadRequest("Book title is required.");

        var created = _service.Create(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BookDto dto)
    {
        var success = _service.Update(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _service.Delete(id);
        return success ? NoContent() : NotFound();
    }
}
