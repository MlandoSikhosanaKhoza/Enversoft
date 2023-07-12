using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Enversoft.Web.Security;
using Enversoft.Web.Services;
using System.Data;

namespace Enversoft.Web.Controllers
{
    [CustomAuthorization(Roles ="Admin")]
    public class OrderStatsController : Controller
    {
        private EnversoftClient _shopWorldClient;
        public OrderStatsController(EnversoftClient shopWorldClient)
        {
            _shopWorldClient = shopWorldClient;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CustomerNumOrdersList = await _shopWorldClient.Order_GetNumberOfCustomerOrdersAsync();
            ViewBag.CustomerTotalSpentList = await _shopWorldClient.Order_GetTotalSpentOfCustomerOrdersAsync();
            ViewBag.CustomerAverageSpentList = await _shopWorldClient.Order_GetAverageSpentOfCustomerOrdersAsync();
            return View();
        }
    }
}
