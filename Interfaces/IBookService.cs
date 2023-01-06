using GraphQLDemo.Data;
using GraphQLDemo.Domain.DTO;

namespace GraphQLDemo.Interfaces
{
    public interface IBookService
    {
        public List<BookDTO> GetBooks();
        public bool Add(BookDTO book);
        public List<BookDTO> GetAll(BookFilter filter);
    }
}
