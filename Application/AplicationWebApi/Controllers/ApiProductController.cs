using AutoMapper;
using BLL.Servises;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(ProductViewModel productVM)
        {
            if(productVM != null)
            {
                var product = _mapper.Map<ProductViewModel, Product>(productVM);
                var res = await _productService.AddProduct(product);
            }
            return new EmptyResult();
        }
        [HttpGet]
        [Route("getAllProducts")]
        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var productList = await _productService.GetAllProducts();
            var mapRes = _mapper.Map<List<Product>, List<ProductViewModel>>(productList);
            return mapRes;
        }
    }
}
