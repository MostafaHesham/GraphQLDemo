using GraphQLDemo.Data;

namespace GraphQLDemo.GraphQL.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Title).Type<StringType>();
            descriptor.Field(a => a.PublishNumber).Type<IntType>();
            descriptor.Field(a => a.PagesCount).Type<IntType>();
        }
    }
}
