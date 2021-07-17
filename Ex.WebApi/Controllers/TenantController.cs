using Ex.Application.Interfaces;
using Ex.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ApiController
    {
        private readonly ITenantAppService _tenantAppService;
        public TenantController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }
        [AllowAnonymous]
        [HttpGet("GetTenants")]
        public async Task<IEnumerable<TenantViewModel>> Get()
        {
            return await _tenantAppService.GetAll();
        }
        //[CustomAuthorize("tenant", "Write")]
        [AllowAnonymous]
        [HttpPost("CreateTenant")]
        public async Task<IActionResult> Post([FromBody] TenantCreateModel tenantCreateModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _tenantAppService.Add(tenantCreateModel));
        }
    }
}
