using AutoMapper;
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
        private readonly CategoriesService _categoriesService;

        private readonly IMapper _mapper;
        public ApiProductController(ProductService productService, CategoriesService categoriesService, IMapper mapper)
        {
            _productService = productService;
            _categoriesService = categoriesService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(ProductViewModel productVM)
        {
            if (productVM != null)
            {
                var productModel = productVM.ProductModel;
                var characteristicModel = productVM.CharactristicModels;
                var product = _mapper.Map<ProductModel, Product>(productModel);
                var characteristics = _mapper.Map<List<CharactristicModel>, List<Characteristic>>(characteristicModel);
                var res = await _productService.AddProduct(product, characteristics, productVM.ImageViewModels);
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

        [HttpGet]
        [Route("getAllCategories")]
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var result = await _categoriesService.GetAllCategories();
            return result;
        }
    }
}
