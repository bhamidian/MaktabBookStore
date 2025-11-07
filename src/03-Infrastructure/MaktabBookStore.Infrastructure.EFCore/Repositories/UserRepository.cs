using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.UserAgg.Contracts.Repositories;
using MaktabBookStore.Domain.UserAgg.DTOs;
using MaktabBookStore.Domain.UserAgg.Entities;
using MaktabBookStore.Domain.UserAgg.Enums;
using MaktabBookStore.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MaktabBookStore.Infrastructure.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbcontext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public bool Delete(int id)
        {
            var user = _dbcontext.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
                return false;

            _dbcontext.Users.Remove(user);

            return _dbcontext.SaveChanges() > 0;
        }

        public GetUserDTO? GetById(int id)
        {
            var user = _dbcontext.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
                return null;

            return new GetUserDTO
            {
                Id = user.Id,
                MobileNumber = user.MobileNumber,
                Role = user.Role,
            };
        }

        public List<GetUserDTO> GetAll()
        {
            return _dbcontext
                .Users.Select(u => new GetUserDTO
                {
                    Id = u.Id,
                    MobileNumber = u.MobileNumber,
                    Role = u.Role,
                })
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

        public bool Update(GetUserDTO dTO)
        {
            var update = _dbcontext
                .Users.Where(u => u.Id == dTO.Id)
                .ExecuteUpdate(o =>
                    o.SetProperty(u => u.MobileNumber, dTO.MobileNumber)
                        .SetProperty(u => u.Role, dTO.Role)
                );

            return update > 0;
        }
    }
}
