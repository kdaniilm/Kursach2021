﻿using AutoMapper;
using BLL.Servises;
using Domain.Entities;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
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
        private readonly CategoriesService _categoriesService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IMapper _mapper;

        private static List<string> _images = new List<string>();
        public ApiProductController(ProductService productService, CategoriesService categoriesService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoriesService = categoriesService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(ProductViewModel productVM)
        {
            if (productVM != null)
            {
                var productModel = productVM.ProductModel;
                var characteristicModel = productVM.CharactristicModels;
                var product = _mapper.Map<ProductModel, Product>(productModel);
                var characteristics = _mapper.Map<List<CharactristicModel>, List<Characteristic>>(characteristicModel);
                var categoryId = productVM.CategoryModel.Id;
                var res = await _productService.AddProduct(product, characteristics, categoryId, _images);
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


        [HttpPost]
        [Route("add-category")]
        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);
            await _categoriesService.AddCategory(category);
            return new EmptyResult();
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadImages")]
        public async Task<IActionResult> UploadFiles()
        {
            try
            {
                var file = Request.Form.Files[0];
                var guid = Guid.NewGuid().ToString();
                var folderName = Path.Combine(this.Request.Host.Value, $"wwwroot", $"Images");

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"Images");
                var dirPath = Path.Combine(pathToSave, guid);
                Directory.CreateDirectory(dirPath);

                string webRootPath = _webHostEnvironment.WebRootPath;
                string contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(webRootPath, "Images", guid);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    _images.Add(fullPath);

                    return Ok(new { dbPath });

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("getAllCategories")]
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var result = await _categoriesService.GetAllCategories();
            return result;
        }
    }
}
