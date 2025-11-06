using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.AuthorAgg.DTOs;

namespace MaktabBookStore.Domain.AuthorAgg.Contracts.Services
{
    public interface IAuthorService
    {
        List<GetAuthorDTO> GetAll();
        ResultDTO<bool> Create(string Name);
    }
}
