using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.UserAgg.DTOs;

namespace MaktabBookStore.Domain.UserAgg.Contracts.Services
{
    public interface IUserService
    {
        ResultDTO<UserLoginDTO> Login(string mobilenumber, string password);
        ResultDTO<bool> Register(RegisterDTO dTO);
        ResultDTO<bool> IsMobileExist(string mobilenumber);
        List<GetUserDTO> GetUsers();

    }
}
