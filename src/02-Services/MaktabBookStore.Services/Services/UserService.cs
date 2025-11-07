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

        public ResultDTO<bool> Delete(int id)
        {
            var delete = _userRepository.Delete(id);

            if (delete)
                return ResultDTO<bool>.Success("کاربر با موفقیت حذف شد");

            return ResultDTO<bool>.Fail("مشکلی در حذف کاربر پیش امد");
        }

        public ResultDTO<GetUserDTO?> GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
                return ResultDTO<GetUserDTO?>.Fail(message: "کاربر پیدا نشد", data: null);

            return ResultDTO<GetUserDTO?>.Success(data: user);
        }

        public List<GetUserDTO> GetAll()
        {
            return _userRepository.GetAll();
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

        public ResultDTO<bool> Update(GetUserDTO dTO)
        {
            var user = _userRepository.Update(dTO);

            if (user)
                return ResultDTO<bool>.Success(message: "اطلاعات با موفقیت اپدیت شد");

            return ResultDTO<bool>.Fail(message: "مشکلی در بروزرسانی اطلاعات به وجود امد");
        }
    }
}
