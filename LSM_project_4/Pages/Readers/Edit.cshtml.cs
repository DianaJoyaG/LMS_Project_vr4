using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Interfaces;
using LMS_project_4.Models;

public class EditReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository; 

    [BindProperty]
    public Reader Reader { get; set; }

    public EditReaderModel(IReaderRepository readerRepository)
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
        if (!ModelState.IsValid)
        {
            return Page(); 
        }

        var readerToUpdate = _readerRepository.GetReaderById(Reader.IDReader); 

        if (readerToUpdate == null)
        {
            return NotFound(); 
        }
        _readerRepository.UpdateReader(Reader);

        return RedirectToPage("./Index"); 
    }
}
