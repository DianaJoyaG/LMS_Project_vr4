using Microsoft.AspNetCore.Mvc;
using LMS_project_4.Models;
using LMS_project_4.Interfaces; 


namespace LMS_project_4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowingController : Controller
    {
        private readonly IBorrowingRepository _borrowingRepository;

        public BorrowingController(IBorrowingRepository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        // GET: Borrowing
        [HttpGet]
        public ActionResult<IEnumerable<Borrowing>> GetAllBorrowings()
        {
            return Ok(_borrowingRepository.GetAllBorrowings());
        }

        // GET: Borrowing/{id}
        [HttpGet("{id}")]
        public ActionResult<Borrowing> GetBorrowingById(int id)
        {
            var borrowing = _borrowingRepository.GetBorrowingById(id);
            if (borrowing != null)
            {
                return Ok(borrowing);
            }
            return NotFound();
        }

        // POST: Borrowing
        [HttpPost]
        public ActionResult<Borrowing> CreateBorrowing([FromBody] Borrowing borrowing)
        {
            var createdBorrowing = _borrowingRepository.AddBorrowing(borrowing);
            return CreatedAtAction(nameof(GetBorrowingById), new { id = createdBorrowing.IDBorrowing }, createdBorrowing);
        }

        // PUT: Borrowing/{id}
        [HttpPut("{id}")]
        public ActionResult<Borrowing> UpdateBorrowing(int id, [FromBody] Borrowing borrowing)
        {
            if (id != borrowing.IDBorrowing)
            {
                return BadRequest();
            }

            var updatedBorrowing = _borrowingRepository.UpdateBorrowing(borrowing);
            if (updatedBorrowing == null)
            {
                return NotFound();
            }

            return Ok(updatedBorrowing);
        }

        // DELETE: Borrowing/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBorrowing(int id)
        {
            _borrowingRepository.DeleteBorrowing(id);
            return NoContent();
        }
    }
}
