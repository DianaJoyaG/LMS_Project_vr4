using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;

public class DeleteBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    public Book Book { get; private set; }

    public DeleteBookModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void OnGet(int id)
    {
        Book = _bookRepository.GetBookById(id);
    }

    public IActionResult OnPost(int id)
    {
        _bookRepository.DeleteBook(id);

        // Redirect to the Index page after deleting the book.
        return RedirectToPage("./Index");
    }
}
