using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;


public class EditBorrowingModel : PageModel
{
    private readonly IBorrowingRepository _borrowingRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IReaderRepository _readerRepository;

    [BindProperty]
    public Borrowing Borrowing { get; set; }
    public SelectList Books { get; set; }
    public SelectList Readers { get; set; }

    public EditBorrowingModel(IBorrowingRepository borrowingRepository, IBookRepository bookRepository, IReaderRepository readerRepository)
    {
        _borrowingRepository = borrowingRepository;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    public IActionResult OnGet(int id)
    {
        Borrowing = _borrowingRepository.GetBorrowingById(id);

        if (Borrowing == null)
        {
            return NotFound();
        }

        Books = new SelectList(_bookRepository.GetAllBooks(), "IDBook", "Title", Borrowing.IDBook);
        Readers = new SelectList(_readerRepository.GetAllReaders(), "IDReader", "NameReader", Borrowing.IDReader);

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Books = new SelectList(_bookRepository.GetAllBooks(), "IDBook", "Title", Borrowing.IDBook);
            Readers = new SelectList(_readerRepository.GetAllReaders(), "IDReader", "NameReader", Borrowing.IDReader);
            return Page();
        }

        _borrowingRepository.UpdateBorrowing(Borrowing);

        return RedirectToPage("./Index");
    }
}
