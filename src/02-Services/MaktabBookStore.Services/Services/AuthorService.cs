using MaktabBookStore.Domain._common.DTOs;
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

        public ResultDTO<bool> Create(string Name)
        {
            var author = _authorRepository.Create(Name);

            if (author)
            {
                return ResultDTO<bool>.Success(message: "نویسنده اضافه شد");
            }
            return ResultDTO<bool>.Fail(message: "مشکلی در ایجاد نویسنده به وجود امد");
        }

        public List<GetAuthorDTO> GetAll()
        {
            return _authorRepository.GetAll();
        }
    }
}
