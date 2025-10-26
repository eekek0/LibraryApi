using Microsoft.AspNetCore.Mvc;
using Library.BLL.DTOs;
using Library.BLL.Services;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var author = _service.GetById(id);
        return author is null ? NotFound() : Ok(author);
    }

    [HttpPost]
    public IActionResult Create(AuthorDto dto)
    {
        var created = _service.Create(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, AuthorDto dto)
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
