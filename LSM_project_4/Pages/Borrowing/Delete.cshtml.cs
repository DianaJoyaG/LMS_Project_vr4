using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;

public class DeleteBorrowingModel : PageModel
{
    private readonly IBorrowingRepository _borrowingRepository;

    [BindProperty]
    public Borrowing Borrowing { get; set; }

    public DeleteBorrowingModel(IBorrowingRepository borrowingRepository)
    {
        _borrowingRepository = borrowingRepository;
    }

    public IActionResult OnGet(int id)
    {
        Borrowing = _borrowingRepository.GetBorrowingById(id);

        if (Borrowing == null)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPost(int id)
    {
        var borrowingToDelete = _borrowingRepository.GetBorrowingById(id);

        if (borrowingToDelete == null)
        {
            return NotFound();
        }

        _borrowingRepository.DeleteBorrowing(id);

        return RedirectToPage("./Index");
    }
}
