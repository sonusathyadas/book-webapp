using BookManager.Data;
using BookManager.Models;
using BookManager.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();

    if (!dbContext.Books.Any())
    {
        dbContext.Books.AddRange(
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic", Language = "English", NumberOfPages = 180, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780743273565-L.jpg" },
            new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian", Language = "English", NumberOfPages = 328, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780451524935-L.jpg" },
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classic", Language = "English", NumberOfPages = 336, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780061120084-L.jpg" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", Language = "English", NumberOfPages = 432, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780141439518-L.jpg" },
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Language = "English", NumberOfPages = 310, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780547928227-L.jpg" },
            new Book { Title = "Dune", Author = "Frank Herbert", Genre = "Science Fiction", Language = "English", NumberOfPages = 688, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780441013593-L.jpg" },
            new Book { Title = "Sapiens", Author = "Yuval Noah Harari", Genre = "History", Language = "English", NumberOfPages = 464, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780062316110-L.jpg" },
            new Book { Title = "Clean Code", Author = "Robert C. Martin", Genre = "Technology", Language = "English", NumberOfPages = 464, CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780132350884-L.jpg" });
        dbContext.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
