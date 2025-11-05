using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Domain.UserAgg.DTOs
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
