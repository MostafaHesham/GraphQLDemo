using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data
{
    public class BookContext : DbContext
    {
        protected BookContext()
        {
        }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(t => t.Books)
                .WithOne(t => t.Author)
                .HasForeignKey(t => t.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(t => t.Author)
                .WithMany(t => t.Books)
                .HasForeignKey(t => t.AuthorId);
        }
    }
}
