using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using MaktabBookStore.Domain._common.Entities;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Domain.UserAgg.Entities
{
    public class User : BaseEntity
    {
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = false;
        public Role Role { get; set; }
    }
}
