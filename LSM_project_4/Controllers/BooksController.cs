using Microsoft.AspNetCore.Mvc;
using LMS_project_4.Models;
using LMS_project_4.Interfaces;
using System.Collections.Generic;

namespace LMS_project_4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: Book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(_bookRepository.GetAllBooks());
        }

        // GET: Book/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        // POST: Book
        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            var createdBook = _bookRepository.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.IDBook }, createdBook);
        }

        // PUT: Book/{id}
        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.IDBook)
            {
                return BadRequest();
            }

            var updatedBook = _bookRepository.UpdateBook(book);
            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        // DELETE: Book/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
            return NoContent();
        }
    }
}
