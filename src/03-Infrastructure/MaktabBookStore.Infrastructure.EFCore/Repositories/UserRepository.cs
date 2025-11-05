using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.UserAgg.Contracts.Repositories;
using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Entities;
using MaktabBookStore.Domain.UserAgg.Enums;
using MaktabBookStore.Infrastructure.EFCore.Persistence;

namespace MaktabBookStore.Infrastructure.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbcontext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public bool ChangeUserCon(int id, bool con)
        {
            var user = new User { Id = id, IsActive = con };

            _dbcontext.Users.Attach(user);
            _dbcontext.Entry(user).Property(u => u.IsActive).IsModified = true;

            return _dbcontext.SaveChanges() > 0;
        }

        public bool DeleteUser(int id)
        {
            var user = _dbcontext.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
                return false;

            _dbcontext.Users.Remove(user);

            return _dbcontext.SaveChanges() > 0;
        }

        public bool EditRole(int id, Role role)
        {
            var user = new User { Id = id, Role = role };

            _dbcontext.Users.Attach(user);
            _dbcontext.Entry(user).Property(u => u.Role).IsModified = true;

            return _dbcontext.SaveChanges() > 0;
        }

        public List<GetUserDTO> GetUsers()
        {
            return _dbcontext
                .Users.Select(u => new GetUserDTO { MobileNumber = u.MobileNumber, Role = u.Role })
                .ToList();
        }

        public bool IsMobileNumberExist(string mobilenumber)
        {
            return _dbcontext.Users.Any(u => u.MobileNumber == mobilenumber);
        }

        public UserLoginDTO? Login(string MobileNumber, string Password)
        {
            var user = _dbcontext
                .Users.Where(u => u.MobileNumber == MobileNumber && u.Password == Password)
                .Select(u => new UserLoginDTO
                {
                    Id = u.Id,
                    MobileNumber = u.MobileNumber,
                    Password = u.Password,
                    Role = u.Role,
                })
                .FirstOrDefault();

            return user;
        }

        public bool Register(RegisterDTO dTO)
        {
            var user = new User
            {
                Id = dTO.Id,
                MobileNumber = dTO.MobileNumber,
                Password = dTO.Password,
                Role = dTO.Role,
            };
            _dbcontext.Users.Add(user);

            return _dbcontext.SaveChanges() > 0;
        }
    }
}
