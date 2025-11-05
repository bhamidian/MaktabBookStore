using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.UserAgg.Contracts.Repositories;
using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.DTOs;

namespace MaktabBookStore.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<GetUserDTO> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public ResultDTO<bool> IsMobileExist(string mobilenumber)
        {
            var isexist = _userRepository.IsMobileNumberExist(mobilenumber);

            if (isexist)
            {
                return ResultDTO<bool>.Fail(message: "شماره موبایل وجود دارد");
            }
            else
            {
                return ResultDTO<bool>.Success();
            }
        }

        public ResultDTO<UserLoginDTO> Login(string mobilenumber, string password)
        {
            var login = _userRepository.Login(mobilenumber, password);

            if (login is not null)
            {
                return ResultDTO<UserLoginDTO>.Success("با موفقیت وارد شدید", login);
            }

            return ResultDTO<UserLoginDTO>.Fail("نام کاربری یا رمز عبور اشتباه می باشد");
        }

        public ResultDTO<bool> Register(RegisterDTO dTO)
        {
            if (_userRepository.IsMobileNumberExist(dTO.MobileNumber))
            {
                return ResultDTO<bool>.Fail(message: "شماره موبایل وجود دارد");
            }
            var result = _userRepository.Register(dTO);

            if (result)
            {
                return ResultDTO<bool>.Success(message: "شما با موفقیت ثبت نام شدید");
            }
            else
            {
                return ResultDTO<bool>.Fail(message: " مشکلی هنگام ثبت نام شما به وجود امد");
            }
        }
    }
}
