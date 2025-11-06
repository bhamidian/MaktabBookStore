using MaktabBookStore.Domain._common.DTOs;
using MaktabBookStore.Domain.BookAgg.Entities;
using MaktabBookStore.Domain.UserAgg.Contracts.Repositories;
using MaktabBookStore.Domain.UserAgg.Contracts.Services;
using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Entities;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ResultDTO<bool> ChangeUserCon(int id, bool con)
        {
            var change = _userRepository.ChangeUserCon(id, con);

            if (change)
                return ResultDTO<bool>.Success(message: "وضعیت کاربر با موفقیت تغییر یافت.");

            return ResultDTO<bool>.Fail(message: "مشکلی در تغییر وضعیت کاربر به وجود امد");
        }

        public ResultDTO<bool> DeleteUser(int id)
        {
            var delete = _userRepository.DeleteUser(id);

            if (delete)
                return ResultDTO<bool>.Success("کاربر با موفقیت حذف شد");

            return ResultDTO<bool>.Fail("مشکلی در حذف کاربر پیش امد");
        }

        public ResultDTO<bool> EditRole(int id, Role role)
        {
            throw new NotImplementedException();
        }

        // public ResultDTO<bool> EditRole(int id, Role role)
        // {
        //     var edit = _userRepository.EditRole(id, role);

        //     if (edit)
        //         return ResultDTO<bool>.Success(message: "نقش با موفقیت تغییر کرد");

        //     return ResultDTO<bool>.Fail(message: "مشکلی در تغییر نفش به وجود امد");
        // }

        public ResultDTO<GetUserDTO?> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user is null)
                return ResultDTO<GetUserDTO?>.Fail(message: "کاربر پیدا مشد", data: null);

            return ResultDTO<GetUserDTO?>.Success(data: user);
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

        public ResultDTO<bool> Update(GetUserDTO dTO)
        {
            var user = _userRepository.Update(dTO);

            if (user)
                return ResultDTO<bool>.Success(message: "اطلاعات با موفقیت اپدیت شد");

            return ResultDTO<bool>.Fail(message: "مشکلی در بروزرسانی اطلاعات به وجود امد");
        }
    }
}
