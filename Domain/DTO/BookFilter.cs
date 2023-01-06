namespace GraphQLDemo.Domain.DTO
{
    public class BookFilter
    {
        public BookFilter()
        {
            Pagination = new PaginationObject();
        }

        public string? SearchString { get; set; }
        public PaginationObject Pagination { get; set; }
    }
}
