using LMS_project_4.Models;
namespace LMS_project_4.Interfaces
{
    public interface IBorrowingRepository
    {
        // Get all borrowings
        IEnumerable<Borrowing> GetAllBorrowings();

        // Get a single borrowing by its ID
        Borrowing GetBorrowingById(int borrowingId);

        // Add a new borrowing
        Borrowing AddBorrowing(Borrowing borrowing);

        // Update an existing borrowing
        Borrowing UpdateBorrowing(Borrowing borrowing);

        // Delete a borrowing
        void DeleteBorrowing(int borrowingId);

    }
}
