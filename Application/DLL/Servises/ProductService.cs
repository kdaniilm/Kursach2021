﻿using BLL.Interfaces;
using Core.Context;
using Domain.Entities;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<bool> AddProduct(Product product, List<Characteristic> characteristics, List<ImageViewModel> images)
        {
            if (product != null && characteristics != null)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                foreach (var characteristic in characteristics)
                {
                    characteristic.Product = product;
                    _context.Characteristics.Add(characteristic);
                }
                //await _context.SaveChangesAsync();

                var savePath = $"../Domain/Images/{product.ProductName}";
                CreateDirectory(savePath);

                foreach (var image in images)
                {
                    var fileName = Path.GetRandomFileName() + image.ImageName;
                    savePath = Path.Combine(savePath, fileName);
                    if (!File.Exists(savePath))
                    {
                        using (FileStream fs = File.Create(savePath))
                        {
                            foreach(var imgByte in image.ImageValue)
                            {
                                fs.WriteByte(imgByte);
                            }
                        }
                    }
                }

                return true;
            }
            return false;
        }

        private void CreateDirectory(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var result = new List<ProductViewModel>();

            var products = await _context.Products.ToListAsync();
            
            foreach(var product in products)
            {
                var productVM = new ProductViewModel();
                productVM.CharactristicModels = new List<CharactristicModel>();
                productVM.ProductModel = new ProductModel() { ProductName = product.ProductName, ProductPrice = product.ProductPrice};
                var characteristics = await _context.Characteristics.Where(c => c.ProductId == product.Id).ToListAsync();
                foreach (var characteristic in characteristics)
                {
                    productVM.CharactristicModels.Add(new CharactristicModel() { CharacteristicName = characteristic.CharacteristicName, CharacteristicValue = characteristic.CharacteristicValue });
                }
                result.Add(productVM);
            }
            return result;
        }

        public Task<bool> UploadImages()
        {
            throw new NotImplementedException();
        }
    }
}
