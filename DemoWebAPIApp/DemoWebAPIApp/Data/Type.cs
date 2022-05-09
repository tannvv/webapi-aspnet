using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Data
{
    [Table("Type")]
    public class Type
    {
        [Key]
         public int ID { get; set; }

        [Required]
        [MaxLength(50)]
         public string TypeName { get; set; }

         public virtual ICollection<Product> Products { get; set; }
    }
}
