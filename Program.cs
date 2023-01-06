using GraphQLDemo;
using GraphQLDemo.Data;
using GraphQLDemo.GraphQL;
using GraphQLDemo.GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Repositories;
using GraphQLDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register custom services
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookService, BookService>();

// Add Application Db Context options
builder.Services.AddPooledDbContextFactory<BookContext>(
    opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDemoConn")));

builder.Services.AddGraphQLServer()
    .AddType<BookType>()
    .AddType<AuthorType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();
    //.AddQueryableOffsetPagingProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});
//app.UseAuthorization();

app.MapRazorPages();

app.Run();
