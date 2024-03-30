using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Interfaces;
using LMS_project_4.Models;

public class DeleteReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; } // Added for binding the reader ID from the query string or route data

    public Reader Reader { get; set; }

    public DeleteReaderModel(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public IActionResult OnGet(int id)
    {
        Reader = _readerRepository.GetReaderById(id); 

        if (Reader == null)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        // No need to pass 'id' again since it's already bound by [BindProperty(SupportsGet = true)]
        var readerToDelete = _readerRepository.GetReaderById(Id); 

        if (readerToDelete == null)
        {
            return NotFound();
        }
        _readerRepository.DeleteReader(Id); 
        return RedirectToPage("./Index");
    }
}
