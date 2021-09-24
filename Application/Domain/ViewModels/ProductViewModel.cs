using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.ViewModels
{
    public class ProductViewModel
    {
        public ProductModel ProductModel { get; set; }
        public List<CharactristicModel> CharactristicModels { get; set; }

        //public List<File> ProductImages { get;set; }
    }
}
