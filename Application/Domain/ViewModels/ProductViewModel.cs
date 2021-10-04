using Domain.Models;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ProductViewModel
    {
        public ProductModel ProductModel { get; set; }
        public List<CharactristicModel> CharactristicModels { get; set; }
    }
}
