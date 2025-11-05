using MaktabBookStore.Domain.UserAgg.Entities;
using MaktabBookStore.Domain.UserAgg.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Infrastructure.EFCore.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { Id = 6, MobileNumber = "09330457600", Password = "1234" ,Role = Role.Admin});
        }
    }
}