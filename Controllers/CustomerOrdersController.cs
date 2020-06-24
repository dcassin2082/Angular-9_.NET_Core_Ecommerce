using JungleApi.Web.Models;
using JungleApi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JungleApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrdersController : ControllerBase
    {
        private ICustomerOrderService _customerOrderService;

        public CustomerOrdersController(ICustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }

        [HttpGet("summary/{id}")]
        public IEnumerable<OrderSummary> GetOrders([FromRoute] int id)
        {
            return _customerOrderService.GetOrders(id);
        }
    }
}