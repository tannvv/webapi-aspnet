using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Data
{
    public class OrderDetail
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte Sale { get; set; }

        // Relationship
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
