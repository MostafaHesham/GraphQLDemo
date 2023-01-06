using GraphQLDemo.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Domain.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
            BookAuthor = new AuthorDTO();
        }

        public int? Id { get; set; }
        public string? Title { get; set; }
        public string PagesCount { get; set; }
        public int PublishNumber { get; set; }
        public int AuthorId { get; set; }
        public AuthorDTO? BookAuthor { get; set; }
    }
}
