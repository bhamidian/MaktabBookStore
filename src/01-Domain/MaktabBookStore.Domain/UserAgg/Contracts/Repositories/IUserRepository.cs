using MaktabBookStore.Domain.UserAgg.DTOs;

namespace MaktabBookStore.Domain.UserAgg.Contracts.Repositories
{
    public interface IUserRepository
    {
        UserLoginDTO? Login(string MobileNumber, string Password);
        bool Register(RegisterDTO dTO);
        List<GetUserDTO> GetUsers();
        bool IsMobileNumberExist(string mobilenumber);
        bool DeleteUser(int id);
    }
}
