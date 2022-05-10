using BookCatalog_Project.Models;

namespace BookCatalog_Project.Repository
{
    public interface IBook 
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBook(Guid id);
        public void CreateBook(Book book);
        public void UpdateBook(Guid id, Book book);
        public void DeleteBook(Guid id);


    }
}
