using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDemo.Data
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string PagesCount { get; set; }
        public int PublishNumber { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
