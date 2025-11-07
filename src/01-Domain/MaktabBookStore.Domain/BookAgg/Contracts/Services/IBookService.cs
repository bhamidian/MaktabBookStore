using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.BookAgg.DTOs;
using MaktabBookStore.Domain.CategoryAgg.DTOs;

namespace MaktabBookStore.Domain.BookAgg.Contracts.Services
{
    public interface IBookService
    {
        List<GetBookDTO> GetAll(int count);
        List<GetBookDTO> GetAll();
        List<GetCategoriesDTO> GetCategories();
        ResultDTO<bool> Create(AddBookDTO dTO);
    }
}
