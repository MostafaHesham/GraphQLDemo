using GraphQLDemo.Data;
using GraphQLDemo.Domain.DTO;
using GraphQLDemo.Interfaces;

namespace GraphQLDemo
{
    public class Query
    {
        //public StaticBook GetStaticBook() => new StaticBook { Title = "Learn C#", Author = "Jon Skeet"};

        //[UseDbContext(typeof(BookContext))]
        //[UsePaging]
        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //public IQueryable<Book> GetAllBooks([ScopedService] BookContext context) => context.Books.AsQueryable();

        //[UseDbContext(typeof(BookContext))]
        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public ICollection<BookDTO> GetRepoBooks([Service] IBookService bookService)
        {
            var result = bookService.GetBooks();
            return result;
        }
    }
}
