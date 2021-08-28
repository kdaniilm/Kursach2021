using BLL.Interfaces;
using Core.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servises
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;
        public ProductService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddProduct(Product product)
        {
            if(product != null)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

    }
}
