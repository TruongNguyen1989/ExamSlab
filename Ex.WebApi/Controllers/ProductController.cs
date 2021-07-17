using Ex.Application.Interfaces;
using Ex.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly IProductAppService _prodcutAppService;
        public ProductController(IProductAppService productAppService)
        {
            _prodcutAppService = productAppService;
        }
        [AllowAnonymous]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Post([FromBody] ProductCreateModel customerCreateModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _prodcutAppService.Add(customerCreateModel));
        }
        [AllowAnonymous]
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Push([FromBody] ProductUpdateModel productUpdateModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _prodcutAppService.Update(productUpdateModel));
        }
    }
}
