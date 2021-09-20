using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductViewModel
    {
        public ProductModel ProductModel { get; set; }
        public List<CharactristicModel> CharactristicModels { get; set; }
    }
}
