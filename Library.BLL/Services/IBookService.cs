using Library.BLL.DTOs;

namespace Library.BLL.Services;

public interface IBookService
{
    IEnumerable<BookDto> GetAll();
    BookDto? GetById(int id);
    BookDto Create(BookDto book);
    bool Update(int id, BookDto updated);
    bool Delete(int id);
}
