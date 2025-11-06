using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.AuthorAgg.Contracts.Repositories;
using MaktabBookStore.Domain.AuthorAgg.DTOs;
using MaktabBookStore.Domain.AuthorAgg.Entities;
using MaktabBookStore.Infrastructure.EFCore.Persistence;

namespace MaktabBookStore.Infrastructure.EFCore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbcontext;

        public AuthorRepository(AppDbContext dbContext) => _dbcontext = dbContext;

        public bool Create(string Name)
        {
            var author = new Author { FullName = Name };
            _dbcontext.Authors.Add(author);

            return _dbcontext.SaveChanges() > 0;
        }

        public List<GetAuthorDTO> GetAll()
        {
            var authors = _dbcontext
                .Authors.Select(a => new GetAuthorDTO { Id = a.Id, Name = a.FullName })
                .ToList();

            return authors;
        }
    }
}
