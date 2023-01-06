using GraphQLDemo.Data;

namespace GraphQLDemo.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
        }
    }
}
