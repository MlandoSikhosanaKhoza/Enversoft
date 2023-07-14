using Enversoft.BusinessLogic;
using Enversoft.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Enversoft.API.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierLogic _supplierLogic;
        public SupplierController(ISupplierLogic supplierLogic)
        {
            _supplierLogic = supplierLogic;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json", Type = typeof(List<Supplier>))]
        public IActionResult _GetAllSuppliers()
        {
            return Ok(_supplierLogic.GetSuppliers());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json", Type = typeof(List<Supplier>))]
        public IActionResult _SearchSuppliers(string Search)
        {
            return Ok(_supplierLogic.SearchSuppliers(Search));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        [Produces("application/json", Type = typeof(Supplier))]
        public IActionResult _GetSupplierById(int SupplierId)
        {
            return Ok(_supplierLogic.GetSupplierById(SupplierId));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Produces("application/json", Type = typeof(Supplier))]
        public IActionResult _AddSupplier(Supplier Supplier)
        {
            return Ok(_supplierLogic.AddSupplier(Supplier));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult _UpdateSupplier(Supplier Supplier)
        {
            return Ok(_supplierLogic.UpdateSupplier(Supplier));
        }
    }
}
