using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicationWebApi.Infrastructure
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
