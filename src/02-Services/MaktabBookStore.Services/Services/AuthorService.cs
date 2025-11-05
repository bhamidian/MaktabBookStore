using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaktabBookStore.Domain.AuthorAgg.Contracts.Repositories;
using MaktabBookStore.Domain.AuthorAgg.Contracts.Services;
using MaktabBookStore.Domain.AuthorAgg.DTOs;

namespace MaktabBookStore.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<GetAuthorDTO> GetAll()
        {
            return _authorRepository.GetAll();
        }
    }
}
