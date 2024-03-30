using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;

public class EditBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    [BindProperty]
    public Book Book { get; set; }

    public EditBookModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void OnGet(int id)
    {
        Book = _bookRepository.GetBookById(id);
    }

    public IActionResult OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page(); 
        }

        // Check if the book exists before attempting an update.
        var existingBook = _bookRepository.GetBookById(id);
        if (existingBook == null)
        {
            return NotFound(); 
        }

        _bookRepository.UpdateBook(Book); 

        // This helps prevent updating the wrong book if there's an ID mismatch.
        if (Book.IDBook != id)
        {
            return BadRequest(); 
        }

        // Redirect to the Index page after successfully updating the book.
        return RedirectToPage("./Index");
    }

}

