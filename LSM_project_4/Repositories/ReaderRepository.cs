using LMS_project_4.Models;
using LMS_project_4.Interfaces;


namespace LMS_project_4.Repositories
{
    public class ReaderRepository:IReaderRepository
    {
        // Simulating a database with a static list
        private static readonly List<Reader> _readers = new List<Reader>
    {
        // Example data
        new Reader { IDReader = 1, NameReader = "Reader One" },
        new Reader { IDReader = 2, NameReader = "Reader Two" },
        new Reader { IDReader = 3, NameReader = "Reader Three" },
        new Reader { IDReader = 4, NameReader = "Reader four" },
        new Reader { IDReader = 5, NameReader = "Reader five" },
    };

        public Reader GetReaderById(int readerId)
        {
            return _readers.FirstOrDefault(r => r.IDReader == readerId);
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return _readers;
        }

        public Reader AddReader(Reader reader)
        {
            // Assuming ReaderId is auto-incremented
            var maxId = _readers.Any() ? _readers.Max(r => r.IDReader) : 0;
            reader.IDReader = maxId + 1;
            _readers.Add(reader);
            return reader;
        }

        public Reader UpdateReader(Reader reader)
        {
            var readerToUpdate = _readers.FirstOrDefault(r => r.IDReader == reader.IDReader);
            if (readerToUpdate != null)
            {
                readerToUpdate.NameReader = reader.NameReader;
            }
            return readerToUpdate;
        }

        public void DeleteReader(int readerId)
        {
            var reader = _readers.FirstOrDefault(r => r.IDReader == readerId);
            if (reader != null)
            {
                _readers.Remove(reader);
            }
        }

    }
}
