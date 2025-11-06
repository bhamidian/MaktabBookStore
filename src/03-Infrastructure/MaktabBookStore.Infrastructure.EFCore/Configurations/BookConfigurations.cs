using MaktabBookStore.Domain.BookAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaktabBookStore.Infrastructure.EFCore.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    ImagePath = "images\\Books\\Silmarilion.jpg",
                    AuthorId = 1,
                    BookTitle = "سیلماریلیون",
                    Price = 350000,
                    Pages = 589,
                    Count = 999,
                    PublishedDate = new DateTime(1999, 09, 09),
                    CategoryId = 1,
                }
            );

            builder.HasData(
                new Book
                {
                    Id = 2,
                    ImagePath = "images\\Books\\Scienceratkig.png",
                    AuthorId = 2,
                    BookTitle = "موش پادشاه حکیم",
                    Price = 250000,
                    Count = 372,
                    Pages = 672,
                    PublishedDate = new DateTime(2002, 01, 01),
                    CategoryId = 1,
                }
            );

            builder.HasData(
                new Book
                {
                    Id = 3,
                    ImagePath = "images\\Books\\Magica.png",
                    AuthorId = 2,
                    BookTitle = "جادو",
                    Price = 250000,
                    Count = 372,
                    Pages = 122,
                    PublishedDate = new DateTime(2003, 01, 01),
                    CategoryId = 1,
                }
            );
            builder.HasData(
                new Book
                {
                    Id = 4,
                    ImagePath = "images\\Books\\Romceronvel.png",
                    AuthorId = 2,
                    BookTitle = "رمان شهر رم",
                    Price = 250000,
                    Count = 372,
                    Pages = 193,
                    PublishedDate = new DateTime(2003, 02, 01),
                    CategoryId = 1,
                }
            );

            builder.HasData(
                new Book
                {
                    Id = 5,
                    ImagePath = "images\\Books\\MagicStory.png",
                    AuthorId = 2,
                    BookTitle = "داستان جادو",
                    Price = 250000,
                    Count = 422,
                    Pages = 111,
                    PublishedDate = new DateTime(2000, 02, 01),
                    CategoryId = 1,
                }
            );

            builder.HasData(
                new Book
                {
                    Id = 6,
                    ImagePath = "images\\Books\\MysteryThriiler.png",
                    AuthorId = 2,
                    BookTitle = "معمای وحشتناک",
                    Price = 250000,
                    Count = 402,
                    Pages = 403,
                    PublishedDate = new DateTime(2003, 02, 01),
                    CategoryId = 1,
                }
            );

            builder.HasData(
                new Book
                {
                    Id = 7,
                    ImagePath = "images\\Books\\Starweaverslegacy.png",
                    AuthorId = 2,
                    BookTitle = "میراث استارویور",
                    Price = 250000,
                    Count = 402,
                    Pages = 222,
                    PublishedDate = new DateTime(2003, 03, 01),
                    CategoryId = 1,
                }
            );
        }
    }
}
