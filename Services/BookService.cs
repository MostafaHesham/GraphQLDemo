using GraphQLDemo.Data;
using GraphQLDemo.Domain.DTO;
using GraphQLDemo.Interfaces;

namespace GraphQLDemo.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public bool Add(BookDTO book)
        {
            Book book1 = new Book
            {
                PagesCount = book.PagesCount,
                PublishNumber = book.PublishNumber,
                Title = book.Title,
                AuthorId = book.AuthorId
            };
            return _bookRepository.Add(book1);
        }

        public List<BookDTO> GetAll(BookFilter filter)
        {
            List<BookDTO> books = new List<BookDTO>();
            var result = _bookRepository.GetAll(filter).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    var bookDto = new BookDTO
                    {
                        AuthorId = item.AuthorId,
                        Id = item.Id,
                        PagesCount = item.PagesCount,
                        PublishNumber = item.PublishNumber,
                        Title = item.Title,
                        BookAuthor = 
                        {
                            Name = item.Author.Name,
                            Id = item.Author.Id
                        }
                    };
                    books.Add(bookDto);
                }
            }
            return books;
        }

        public List<BookDTO> GetBooks()
        {
            var result = _bookRepository.GetBooks().ToList();
            var listDTO = new List<BookDTO>();
            foreach (var item in result)
            {
                var bookDto = new BookDTO
                {
                    AuthorId = item.AuthorId,
                    Id = item.Id,
                    PagesCount = item.PagesCount,
                    PublishNumber = item.PublishNumber,
                    Title = item.Title,
                    BookAuthor =
                    {
                        Id = item.AuthorId,
                        Name = item.Author.Name
                    }
                };
                listDTO.Add(bookDto);
            }
            return listDTO;
        }
    }
}
