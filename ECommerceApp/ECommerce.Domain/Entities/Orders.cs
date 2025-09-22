using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    internal class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
