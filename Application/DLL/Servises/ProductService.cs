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
        public async Task<bool> AddProduct(Product product, List<Characteristic> characteristics)
        {
            //foreach (var characteristic in characteristics)
            //{
            //    if (characteristic != null)
            //    {
            //        _context.Characteristics.Add(characteristic);
            //    }
            //}
            //await _context.SaveChangesAsync();
            //if(product != null)
            //{
            //    _context.Products.Add(product);
            //    await _context.SaveChangesAsync();
            //    return true;
            //}
            if (product != null && characteristics != null)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                //var productId = _context.Products.FirstOrDefault(p => p.ProductName == product.ProductName).Id;

                foreach (var characteristic in characteristics)
                {
                    characteristic.Product = product;
                    //characteristic.ProductId = productId;
                    _context.Characteristics.Add(characteristic);
                }
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
