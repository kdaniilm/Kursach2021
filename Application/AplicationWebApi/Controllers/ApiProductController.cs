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
        public ApiProductController()
        {

        }
        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct()
        {
            return new EmptyResult();
        }
        [HttpPost]
        [Route("getAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return new EmptyResult();
        }
    }
}
