using MaktabBookStore.Domain.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace MaktabBookStore.Infrastructure.EFCore.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasData(new Category
                {
                    Id = 1,
                    Name = "رمان و داستان",
                    Logo = "📖"
                });

            builder
                .HasData(new Category
                {
                    Id = 2,
                    Name = "علمی و تاریخی",
                    Logo = "🏺"
                });

            builder
                .HasData(new Category
                {
                    Id = 3,
                    Name = "فلسفه و منطق",
                    Logo = "🧠"
                });

            builder
                .HasData(new Category
                {
                    Id = 4,
                    Name = "کودک و نوجوان",
                    Logo = "🧒"
                });

            builder
                .HasData(new Category
                {
                    Id = 5,
                    Name = "هنر و معماری",
                    Logo = "🎨"
                });
        }
    }
}