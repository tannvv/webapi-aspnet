using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public byte Sale { get; set; }

        public int? TypeID { get; set; }
        [ForeignKey("TypeID")]
        public Type Type { get; set; }

        // Relationship
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
