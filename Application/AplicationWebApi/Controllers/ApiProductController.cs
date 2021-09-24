﻿using AutoMapper;
using BLL.Servises;
using Domain.Entities;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AplicationWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;
        public ApiProductController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(ProductViewModel productVM/*, [FromForm]List<IFormFile> images*/)
        {
            //if(images != null && images.Count != 0)
            //{
            //    foreach(var image in images)
            //    {
            //        var filePath = "../Domain/Images";
            //        await using var stream = new FileStream(filePath, FileMode.Create);
            //        await image.CopyToAsync(stream);
            //    }
            //}



            if (productVM != null)
            {
                var productModel = productVM.ProductModel;
                var characteristicModel = productVM.CharactristicModels;
                var product = _mapper.Map<ProductModel, Product>(productModel);
                var characteristics = _mapper.Map<List<CharactristicModel>, List<Characteristic>>(characteristicModel);
                var res = await _productService.AddProduct(product, characteristics);
            }
            return new EmptyResult();
        }
        [HttpGet]
        [Route("getAllProducts")]
        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var productList = await _productService.GetAllProducts();

            return productList;
        }
    }
}
