using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_4.Interfaces;
using LMS_project_4.Models;


public class IndexReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository; 

    public List<Reader> Readers { get; private set; }

    public IndexReaderModel(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public void OnGet()
    {
        Readers = _readerRepository.GetAllReaders().ToList();
    }
}
