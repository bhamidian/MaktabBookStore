using MaktabBookStore.Domain.AuthorAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaktabBookStore.Infrastructure.EFCore.Configurations
{
    public class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(new Author { Id = 1, FullName = "جی آر آر تالکین" });

            builder.HasData(new Author { Id = 2, FullName = "چت جی پی تی" });
        }
    }
}
