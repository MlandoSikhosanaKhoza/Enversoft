using AutoMapper;
using Enversoft.Shared;
using Enversoft.Web.Models;
using Enversoft.Web.Security;
using Enversoft.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Enversoft.Web.Controllers
{
    [CustomAuthorization(Roles = "Admin")]
    public class SupplierController : Controller
    {
        private EnversoftClient client;
        private readonly IMapper _mapper;
        public SupplierController(EnversoftClient client,IMapper mapper) {
            this.client = client;
            this._mapper = mapper;
        }
        // GET: SupplierController
        public async Task<IActionResult> Index(string Search="")
        {
            List<Supplier> suppliers =string.IsNullOrEmpty(Search)?
                (await client.Supplier_GetAllSuppliersAsync()).ToList():
                (await client.Supplier_SearchSuppliersAsync(Search)).ToList();
            return View(suppliers);
        }

        // GET: SupplierController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Supplier supplier = await client.Supplier_GetSupplierByIdAsync(id);
            return View();
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            SupplierModel supplierModel = new SupplierModel();
            return View(supplierModel);
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierModel Input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Supplier supplier=_mapper.Map<Supplier>(Input);
                    await client.Supplier_AddSupplierAsync(supplier);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Input);
            }
        }

        // GET: SupplierController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Supplier supplier = await client.Supplier_GetSupplierByIdAsync(id);
            SupplierModel supplierModel = _mapper.Map<SupplierModel>(supplier);
            return View(supplierModel);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupplierModel Input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Supplier supplier = _mapper.Map<Supplier>(Input);
                    await client.Supplier_UpdateSupplierAsync(supplier);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
