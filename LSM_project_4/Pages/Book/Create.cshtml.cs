using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;

public class CreateBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    [BindProperty]
    public Book Book { get; set; }

    public CreateBookModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IActionResult OnGet()
    {
        // You can provide any initial data or perform other actions required when the Create page is loaded.
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _bookRepository.AddBook(Book);

        // Redirect to the Index page after creating the book.
        return RedirectToPage("./Index");
    }
}
