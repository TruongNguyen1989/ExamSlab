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
    public class OrderController : ApiController
    {
        private readonly IOrderAppService _orderAppService;
        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        [AllowAnonymous]
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Post([FromBody] CreateOrderModel createOrderModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _orderAppService.Add(createOrderModel));
        }
        [AllowAnonymous]
        [HttpGet("GetOrders")]
        public async Task<IEnumerable<OrderViewModel>> GetOrders()
        {
            return await _orderAppService.GetOrders();
        }
        [AllowAnonymous]
        [Route("GetOrder/{Id}")]
        [HttpGet]
        public async Task<OrderViewModel> GetOrder([FromHeader] DeleteOrderLineModel Order)
        {
            return await _orderAppService.GetOrder(Order.Id);
        }
        [AllowAnonymous]
        [HttpPut("UpdateOrderItem")]
        public async Task<IActionResult> UpdateOrderItem([FromBody] OrderLineUpdateModel orderLineUpdate)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _orderAppService.UpdateOrderItem(orderLineUpdate));
        }
        [AllowAnonymous]
        [HttpPut("RemoveOrderItem/{Id}")]
        public async Task<IActionResult> RemoveOrderItem([FromHeader] DeleteOrderLineModel deleteOrderLineModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _orderAppService.DeleteOrderItem(deleteOrderLineModel));
        }
    }
}
