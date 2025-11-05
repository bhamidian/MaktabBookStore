using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.AuthorAgg.Contracts.Repositories;
using MaktabBookStore.Domain.AuthorAgg.DTOs;
using MaktabBookStore.Infrastructure.EFCore.Persistence;

namespace MaktabBookStore.Infrastructure.EFCore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbcontext;

        public AuthorRepository(AppDbContext dbContext) => _dbcontext = dbContext;

        public List<GetAuthorDTO> GetAll()
        {
            var authors = _dbcontext
                .Authors.Select(a => new GetAuthorDTO { Id = a.Id, Name = a.FullName })
                .ToList();

            return authors;
        }
    }
}
