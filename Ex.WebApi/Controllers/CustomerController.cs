using Ex.Application.Interfaces;
using Ex.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;
        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        [AllowAnonymous]
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> Post([FromBody] CustomerCreateModel customerCreateModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _customerAppService.Add(customerCreateModel));
        }
    }
}
