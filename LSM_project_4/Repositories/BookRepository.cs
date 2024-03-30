using LMS_project_4.Models;
using LMS_project_4.Interfaces;

namespace LMS_project_4.Repositories
{
    public class BookRepository: IBookRepository
    {
        // Simulating a database with a static list
        private static readonly List<Book> _books = new List<Book>
        {
            new Book { IDBook = 1, Title = "Example Book 1", Author = "Author 1", Description = "Description 1" },
            new Book { IDBook = 2, Title = "Example Book 2", Author = "Author 2", Description = "Description 2" },
            // Add more example books here
        };

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int iDBook)
        {
            return _books.FirstOrDefault(b => b.IDBook == iDBook);
        }

        public Book AddBook(Book book)
        {
            // Simulate auto-incrementing primary key on add
            if (!_books.Any())
            {
                book.IDBook = 1;
            }
            else
            {
                int maxId = _books.Max(b => b.IDBook);
                book.IDBook = maxId + 1;
            }

            _books.Add(book);
            return book;
        }

        public Book UpdateBook(Book book)
        {
            var bookToUpdate = _books.FirstOrDefault(b => b.IDBook == book.IDBook);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Description = book.Description;
                // Update other properties as needed
            }
            return bookToUpdate;
        }

        public void DeleteBook(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.IDBook == bookId);
            if (book != null)
            {
                _books.Remove(book);
            }
        }


    }
}
