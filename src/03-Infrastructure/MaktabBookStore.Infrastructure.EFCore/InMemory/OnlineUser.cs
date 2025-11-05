using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaktabBookStore.Domain.UserAgg.Enums;

namespace MaktabBookStore.Infrastructure.EFCore.InMemory
{
    public class OnlineUser
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public Role Role { get; set; }
    }
}
