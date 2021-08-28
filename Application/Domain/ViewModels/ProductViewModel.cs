using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float ProductPrice { get; set; }
    }
}
