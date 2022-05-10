using BookCatalog_Project.Dtos;
using BookCatalog_Project.Models;
using BookCatalog_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_Project.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BooksConrtoller :ControllerBase
    {
        private IBook _BookRepository;
        public BooksConrtoller(IBook bookRepository)

        {
            _BookRepository = bookRepository;
            //_BookRepository = new InMemoryBookRepository();

        }
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            return _BookRepository.GetBooks()
                .Select(x => new BookDTO { Id = x.Id, Title = x.Title, Price = x.Price }).ToList();
               
                
        }
        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBooks(Guid id)
        {

            var book = _BookRepository.GetBook(id);
            if(book==null)
                return NotFound();  
            
            var BookDTO = new BookDTO { Id=book.Id, Title=book.Title,Price=book.Price};

            return BookDTO;


        }
        [HttpPost]
        public ActionResult CreateBook(CreateOrUpdateBookcs book )
        {
            var mybook = new Book();
            mybook.Id = Guid.NewGuid();
            mybook.Title = book.Title;
            mybook.Price = book.Price;

            _BookRepository.CreateBook(mybook);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, CreateOrUpdateBookcs book)
        {
            var mybook = _BookRepository.GetBook(id);
            if (mybook == null)
                return NotFound();
            mybook.Title = book.Title;
            mybook.Price = book.Price;

            _BookRepository.UpdateBook(id, mybook);


            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var book = _BookRepository.GetBook(id);
            if (book == null) 
                return NotFound();
            _BookRepository.DeleteBook(id);
            return Ok();
        }


    }
}
