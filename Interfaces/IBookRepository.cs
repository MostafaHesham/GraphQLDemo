using GraphQLDemo.Data;
using GraphQLDemo.Domain.DTO;

namespace GraphQLDemo.Interfaces
{
    public interface IBookRepository
    {
        public IQueryable<Book> GetBooks();
        public bool Add(Book book);
        public IQueryable<Book> GetAll(BookFilter filter);

    }
}
