using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;

public class IndexBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    public IEnumerable<Book> Books { get; private set; }

    public IndexBookModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void OnGet()
    {
        Books = _bookRepository.GetAllBooks();
    }
}
