using MaktabBookStore.Domain.AuthorAgg.Contracts.Repositories;
using MaktabBookStore.Domain.AuthorAgg.Contracts.Services;
using MaktabBookStore.Domain.BookAgg.Contracts.Repositories;
using MaktabBookStore.Domain.BookAgg.Contracts.Services;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Repositories;
using MaktabBookStore.Domain.CategoryAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.Contracts.Repositories;
using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Infrastructure.EFCore.Persistence;
using MaktabBookStore.Infrastructure.EFCore.Repositories;
using MaktabBookStore.Services.Services;

namespace MaktabBookStore.Presentation.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

                    builder.Services.AddScoped<IBookService, BookService>();
                    builder.Services.AddScoped<IBookRepository, BookRepository>();
                    builder.Services.AddScoped<IUserRepository, UserRepository>();
                    builder.Services.AddScoped<IUserService, UserService>();
                    builder.Services.AddScoped<ICategoryService, CategoryService>();
                    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
                    builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
                    builder.Services.AddScoped<IAuthorService, AuthorService>();
                    builder.Services.AddDbContext<AppDbContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
