using Microsoft.AspNetCore.Mvc;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;


namespace LMS_project_4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderController(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        // GET: Reader
        [HttpGet]
        public ActionResult<IEnumerable<Reader>> GetAllReaders()
        {
            var readers = _readerRepository.GetAllReaders();
            return Ok(readers);
        }

        // GET: Reader/{id}
        [HttpGet("{id}")]
        public ActionResult<Reader> GetReaderById(int id)
        {
            var reader = _readerRepository.GetReaderById(id);
            if (reader != null)
            {
                return Ok(reader);
            }
            return NotFound($"Reader with ID {id} not found.");
        }

        // POST: Reader
        [HttpPost]
        public ActionResult<Reader> CreateReader([FromBody] Reader reader)
        {
            var newReader = _readerRepository.AddReader(reader);
            return CreatedAtAction(nameof(GetReaderById), new { id = newReader.IDReader }, newReader);
        }

        // PUT: Reader/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateReader(int id, [FromBody] Reader reader)
        {
            if (id != reader.IDReader)
            {
                return BadRequest("Reader ID mismatch");
            }

            var existingReader = _readerRepository.GetReaderById(id);
            if (existingReader == null)
            {
                return NotFound($"Reader with ID {id} not found.");
            }

            _readerRepository.UpdateReader(reader);
            return NoContent(); // Indicating successful update without returning data
        }

        // DELETE: Reader/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReader(int id)
        {
            var existingReader = _readerRepository.GetReaderById(id);
            if (existingReader == null)
            {
                return NotFound($"Reader with ID {id} not found.");
            }

            _readerRepository.DeleteReader(id);
            return NoContent(); // Indicating successful deletion
        }
    }
}
