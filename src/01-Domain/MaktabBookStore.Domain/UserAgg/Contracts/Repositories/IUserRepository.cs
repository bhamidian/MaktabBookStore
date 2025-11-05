using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Domain.UserAgg.Contracts.Repositories
{
    public interface IUserRepository
    {
        UserLoginDTO? Login(string MobileNumber, string Password);
        bool Register(RegisterDTO dTO);
        List<GetUserDTO> GetUsers();
        bool EditRole(int id, Role role);
        bool IsMobileNumberExist(string mobilenumber);
        bool DeleteUser(int id);
        bool ChangeUserCon(int id, bool con);
    }
}
