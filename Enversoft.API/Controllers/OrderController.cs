﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Enversoft.BusinessLogic;
using Enversoft.Shared;
using Enversoft.Shared;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Enversoft.API.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderLogic _orderLogic;
        public OrderController(IOrderLogic orderLogic) {
            _orderLogic = orderLogic;
        }

        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        [Produces("application/json",Type =typeof(List<Order>))]
        public IActionResult _GetAllOrders()
        {
            return Ok(_orderLogic.GetAllOrders());
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Produces("application/json",Type=typeof(List<Order>))]
        public IActionResult _GetOngoingOrdersForCustomer(int CustomerId)
        {
            return Ok(_orderLogic.GetOngoingOrdersForCustomer(CustomerId));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Produces("application/json",Type=typeof(List<Order>))]
        public IActionResult _GetCompleteOrdersForCustomer(int CustomerId)
        {
            return Ok(_orderLogic.GetCompleteOrdersForCustomer(CustomerId));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json",Type=typeof(List<Order>))]
        public IActionResult _GetOngoingOrders()
        {
            return Ok(_orderLogic.GetOngoingOrders());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json",Type=typeof(List<Order>))]
        public IActionResult _GetCompleteOrders()
        {
            return Ok(_orderLogic.GetCompleteOrders());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json", Type = typeof(List<CustomerOrderResult>))]
        public IActionResult _GetNumberOfCustomerOrders() { 
            return Ok(_orderLogic.GetNumberOfCustomerOrders());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json", Type = typeof(List<CustomerOrderPriceResult>))]
        public IActionResult _GetTotalSpentOfCustomerOrders() {
            return Ok(_orderLogic.GetTotalSpentOfCustomerOrders());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json", Type = typeof(List<CustomerOrderPriceResult>))]
        public IActionResult _GetAverageSpentOfCustomerOrders()
        {
            return Ok(_orderLogic.GetAverageSpentOfCustomerOrders());
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Produces("application/json", Type = typeof(Order))]
        public IActionResult _AddOrder(Order Order) { 
            return Ok(_orderLogic.AddOrder(Order));
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(Order))]
        public IActionResult _GetOrder(int OrderId)
        {
            return Ok(_orderLogic.GetOrder(OrderId));
        }

        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult _UpdateOrder(Order Order) {
            return Ok(_orderLogic.UpdateOrder(Order));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult _DeleteOrder(int OrderId) { 
            return Ok(_orderLogic.DeleteOrder(OrderId));
        }
    }
}
