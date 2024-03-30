using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Interfaces;
using LMS_project_4.Models;

public class CreateReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository; 

    [BindProperty]
    public Reader Reader { get; set; }

    public CreateReaderModel(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _readerRepository.AddReader(Reader); 
      
        return RedirectToPage("./Index");
    }
}
