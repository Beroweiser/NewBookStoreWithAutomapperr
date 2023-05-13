using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController (BookStoreDbContext context)
        {
            _context = context;
        }
       /* private static List<Book> BookList = new List<Book>() {

            new Book
            {
                Id = 1,

                Title = "Lean Startup",

                GenreId = 1,// Personal Growth

                PageCount = 200,

                PublishDate = new DateTime(2001,06,12)
            },
            new Book
            {
                Id = 2,

                Title = "HerLand",

                GenreId = 2,// Science Fiction

                PageCount = 250,

                PublishDate = new DateTime(2006,06,12)
            },
            new Book
            {
                Id = 3,

                Title = "Dune",

                GenreId = 2,// Science fiction

                PageCount = 540,

                PublishDate = new DateTime(2001,12,12)
            }
        };*/

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {

                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result =  query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        /*
        [HttpGet]
        public Book Get([FromQuery] string id)
        {
            var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }*/
        // post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
            
            return Ok();
        }
        // put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook) {

            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(); }
    }
}
