using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGeneretor
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange
                (
                    new Book
                    {
                       // Id = 1,

                        Title = "Lean Startup",

                        GenreId = 1,// Personal Growth

                        PageCount = 200,

                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,

                        Title = "HerLand",

                        GenreId = 2,// Science Fiction

                        PageCount = 250,

                        PublishDate = new DateTime(2006, 06, 12)
                    },
                    new Book
                    {
                        //Id = 3,

                        Title = "Dune",

                        GenreId = 2,// Science fiction

                        PageCount = 540,

                        PublishDate = new DateTime(2001, 12, 12)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
