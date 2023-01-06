using GraphQLDemo.Data;
using GraphQLDemo.Domain.DTO;
using GraphQLDemo.Interfaces;

namespace GraphQLDemo.GraphQL
{
    public class Mutation
    {
        public async Task<BookDTO> AddBook([Service]IBookService bookService, BookDTO book)
        {

            bookService.Add(book);
            return book;
        }

        public async Task<List<BookDTO>> GetAll([Service] IBookService bookService, BookFilter filter)
        {

            var result =  bookService.GetAll(filter);
            return result;
        }
    }
}
