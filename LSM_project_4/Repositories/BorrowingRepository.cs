using LMS_project_4.Models;
using LMS_project_4.Interfaces;

namespace LMS_project_4.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {

        // Simulating a database with a static list
        private static readonly List<Borrowing> _borrowings = new List<Borrowing>
        {
            new Borrowing
            {
                IDBorrowing = 101,
                IDBook = 1,
                IDReader = 1,
                BorrowedDate = new DateTime(2024, 1, 1),
                ReturnedDate = new DateTime(2024, 1, 15)
            },
            new Borrowing
            {
                IDBorrowing = 101,
                IDBook = 2,
                IDReader = 2,
                BorrowedDate = new DateTime(2024, 2, 1),
                ReturnedDate = null // Assuming the book hasn't been returned yet
            }
        };

        public IEnumerable<Borrowing> GetAllBorrowings()
        {
            return _borrowings;
        }

        public Borrowing GetBorrowingById(int borrowingId)
        {
            return _borrowings.FirstOrDefault(b => b.IDBorrowing == borrowingId);
        }

        public Borrowing AddBorrowing(Borrowing borrowing)
        {
            var maxId = _borrowings.Any() ? _borrowings.Max(b => b.IDBorrowing) : 0;
            borrowing.IDBorrowing = maxId + 1;
            _borrowings.Add(borrowing);
            return borrowing;
        }

        public Borrowing UpdateBorrowing(Borrowing borrowing)
        {
            var borrowingToUpdate = _borrowings.FirstOrDefault(b => b.IDBorrowing == borrowing.IDBorrowing);
            if (borrowingToUpdate != null)
            {
                borrowingToUpdate.IDBook = borrowing.IDBook;
                borrowingToUpdate.IDReader = borrowing.IDReader;
                borrowingToUpdate.BorrowedDate = borrowing.BorrowedDate;
                borrowingToUpdate.ReturnedDate = borrowing.ReturnedDate;
                            }
            return borrowingToUpdate;
        }

        public void DeleteBorrowing(int borrowingId)
        {
            var borrowing = _borrowings.FirstOrDefault(b => b.IDBorrowing == borrowingId);
            if (borrowing != null)
            {
                _borrowings.Remove(borrowing);
            }
        }

    }
}
