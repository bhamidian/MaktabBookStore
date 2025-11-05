using MaktabBookStore.Domain.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaktabBookStore.Domain.CategoryAgg.Contracts.Services
{
    public interface ICategoryService
    {
        List<GetCategoriesDTO> GetAll();
    }
}