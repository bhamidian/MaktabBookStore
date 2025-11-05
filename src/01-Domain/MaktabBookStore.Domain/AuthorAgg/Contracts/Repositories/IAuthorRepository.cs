using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.AuthorAgg.DTOs;

namespace MaktabBookStore.Domain.AuthorAgg.Contracts.Repositories
{
    public interface IAuthorRepository
    {
        List<GetAuthorDTO> GetAll();

    }
}