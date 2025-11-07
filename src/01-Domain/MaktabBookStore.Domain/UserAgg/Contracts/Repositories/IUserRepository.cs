using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Domain.UserAgg.Contracts.Repositories
{
    public interface IUserRepository
    {
        UserLoginDTO? Login(string MobileNumber, string Password);
        bool Register(RegisterDTO dTO);
        List<GetUserDTO> GetAll();
        bool Update(GetUserDTO dTO);
        bool IsMobileNumberExist(string mobilenumber);
        bool Delete(int id);
        GetUserDTO? GetById(int id);
    }
}
