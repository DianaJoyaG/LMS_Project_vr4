using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;


public class CreateBorrowingModel : PageModel
{
    private readonly IBorrowingRepository _borrowingRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IReaderRepository _readerRepository;

    public SelectList Books { get; set; }
    public SelectList Readers { get; set; }

    [BindProperty]
    public Borrowing Borrowing { get; set; }

    public CreateBorrowingModel(
        IBorrowingRepository borrowingRepository,
        IBookRepository bookRepository,
        IReaderRepository readerRepository)
    {
        _borrowingRepository = borrowingRepository;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    public void OnGet()
    {
        Books = new SelectList(_bookRepository.GetAllBooks(), "IDBook", "Title");
        Readers = new SelectList(_readerRepository.GetAllReaders(), "IDReader", "NameReader");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            // Reload the dropdown lists if the model is not valid
            Books = new SelectList(_bookRepository.GetAllBooks(), "IDBook", "Title");
            Readers = new SelectList(_readerRepository.GetAllReaders(), "IDReader", "NameReader");
            return Page();
        }

        // Add the new borrowing to the repository
        _borrowingRepository.AddBorrowing(Borrowing);

        // Redirect to the Index page after creation
        return RedirectToPage("./Index");
    }
}
