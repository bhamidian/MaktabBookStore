using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using MaktabBookStore.Domain.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaktabBookStore.Infrastructure.EFCore.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "رمان و داستان",
                    LogoPath = "images/Logos/novels.png",
                }
            );

            builder.HasData(
                new Category
                {
                    Id = 2,
                    Name = "علمی و تاریخی",
                    LogoPath = "images/Logos/vast.png",
                }
            );

            builder.HasData(
                new Category
                {
                    Id = 3,
                    Name = "فلسفه و منطق",
                    LogoPath = "images/Logos/brain.png",
                }
            );

            builder.HasData(
                new Category
                {
                    Id = 4,
                    Name = "کودک و نوجوان",
                    LogoPath = "images/Logos/philosophy.png",
                }
            );

            builder.HasData(
                new Category
                {
                    Id = 5,
                    Name = "هنر و معماری",
                    LogoPath = "images/Logos/art.png",
                }
            );
        }
    }
}
