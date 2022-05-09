using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Data
{
    public enum OrderStatus { 
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class Order
    {
        public Guid OrderID { set; get; }
        public DateTime OrderDate { set; get; }
        public DateTime? DeliveryDate { set; get; }
        public OrderStatus OrderStatus { set; get; }
        public string Receiver;
        public string Address {set ; get;}
        public string PhoneNumber { set; get; }

        // Relationship
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order() {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
