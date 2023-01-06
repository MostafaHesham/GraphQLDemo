using GraphQLDemo.Data;
using GraphQLDemo.Domain.DTO;
using GraphQLDemo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContextFactory<BookContext> _dbContextFactory;


        //private readonly BookContext _dbContext;

        public BookRepository(/*BookContext dbContext,*/ IDbContextFactory<BookContext> dbContextFactory)
        {
            //_dbContext = dbContext;
            _dbContextFactory = dbContextFactory;
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Database.EnsureCreated();
            }
        }

        public bool Add(Book book)
        {
            try
            {
                var applicationDbContext = _dbContextFactory.CreateDbContext();

                applicationDbContext.Books.Add(book);
                applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }

        public IQueryable<Book> GetAll(BookFilter filter)
        {
            var skip = --filter.Pagination.PageNumber * filter.Pagination.PageSize;
            var applicationDbContext = _dbContextFactory.CreateDbContext();
            var result = applicationDbContext.Books
                .Where(x => x.Title.ToLower().Contains(filter.SearchString.ToLower()))
                .Skip(skip)
                .Take(filter.Pagination.PageSize)
                .AsQueryable()
                .Include(a => a.Author);
            return result;
        }

        public IQueryable<Book> GetBooks()
        {
            //var result =_dbContext.Books.AsQueryable();
            var applicationDbContext = _dbContextFactory.CreateDbContext();
            var result = applicationDbContext.Books.AsQueryable().Include(a => a.Author);
            return result;
        }
    }
}
