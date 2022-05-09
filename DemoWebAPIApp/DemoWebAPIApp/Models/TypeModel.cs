using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Models
{
    public class TypeModel
    {
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
