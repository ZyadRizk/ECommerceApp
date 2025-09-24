using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Status { get; set; } = UserRole.Customer ;

        public Cart? Cart { get; set; }
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
