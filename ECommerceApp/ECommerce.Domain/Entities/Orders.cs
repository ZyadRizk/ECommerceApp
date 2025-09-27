using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public bool IsDeleted { get; set; }
        public required string ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
