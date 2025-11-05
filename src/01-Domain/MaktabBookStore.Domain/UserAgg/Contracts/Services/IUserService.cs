using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Domain.UserAgg.Contracts.Services
{
    public interface IUserService
    {
        ResultDTO<UserLoginDTO> Login(string mobilenumber, string password);
        ResultDTO<bool> Register(RegisterDTO dTO);
        ResultDTO<bool> IsMobileExist(string mobilenumber);
        List<GetUserDTO> GetUsers();
        ResultDTO<bool> EditRole(int id, Role role);
        ResultDTO<bool> ChangeUserCon(int id, bool con);
        ResultDTO<bool> DeleteUser(int id);




    }
}
