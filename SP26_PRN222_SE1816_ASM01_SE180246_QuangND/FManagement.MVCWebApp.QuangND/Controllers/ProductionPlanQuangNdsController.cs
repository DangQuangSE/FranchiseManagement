using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FManagement.Entities.QuangND.Entities;
using FManagement.Services.QuangND;

namespace FManagement.MVCWebApp.QuangND.Controllers
{
    public class ProductionPlanQuangNdsController : Controller
    {
        // private readonly FranchiseManagementContext _context;
        private readonly IProductPlanQuangNDService _productPlanQuangNDService;
        private readonly StoreOrderItemQuangNDService _storeOrderItemQuangNDService;

        //public ProductionPlanQuangNdsController(FranchiseManagementContext context)
        //{
        //    _context = context;
        //}
        public ProductionPlanQuangNdsController(IProductPlanQuangNDService productPlanQuangNDService,
            StoreOrderItemQuangNDService storeOrderItemQuangNDService)
        {
            _productPlanQuangNDService = productPlanQuangNDService;
            _storeOrderItemQuangNDService = storeOrderItemQuangNDService;
        }

        // GET: ProductionPlanQuangNds
        public async Task<IActionResult> Index()
        {
            //var franchiseManagementContext = _context.ProductionPlanQuangNds.Include(p => p.Kitchen).Include(p => p.StoreOrderItem);
            //return View(await franchiseManagementContext.ToListAsync());
            var items = await _productPlanQuangNDService.GetAllAsync();
            return View(items);
        }

        // GET: ProductionPlanQuangNds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productionPlanQuangNd = await _productPlanQuangNDService.GetByIdAysnc(id.Value);
            if (productionPlanQuangNd == null)
            {
                return NotFound();
            }

            return View(productionPlanQuangNd);
        }


        // GET: ProductionPlanQuangNds/Create
        public async Task<IActionResult> Create()
        {
            var StoreOrderItemQuangNds = await _storeOrderItemQuangNDService.GetAllAsync();
            ViewData["StoreOrderItemId"] = new SelectList(StoreOrderItemQuangNds, "OrderItemId", "OrderItemId");

            return View();
        }


        // POST: ProductionPlanQuangNds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductionPlanQuangNd productionPlanQuangNd)
        {
            if (ModelState.IsValid)
            {
                var result = await _productPlanQuangNDService.CreateAsync(productionPlanQuangNd);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var StoreOrderItemQuangNds = await _storeOrderItemQuangNDService.GetAllAsync();
            ViewData["StoreOrderItemId"] = new SelectList(StoreOrderItemQuangNds, "OrderItemId", "OrderItemId", productionPlanQuangNd.StoreOrderItemId);
            return View(productionPlanQuangNd);
        }


        // GET: ProductionPlanQuangNds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var productionPlanQuangNd = await _context.ProductionPlanQuangNds.FindAsync(id);
            var productionPlanQuangNd = await _productPlanQuangNDService.GetByIdAysnc(id.Value);
            if (productionPlanQuangNd == null)
            {
                return NotFound();
            }
            var StoreOrderItemQuangNds = await _storeOrderItemQuangNDService.GetAllAsync();
            //ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName", productionPlanQuangNd.KitchenId);
            ViewData["StoreOrderItemId"] = new SelectList(StoreOrderItemQuangNds, "OrderItemId", "OrderItemId", productionPlanQuangNd.StoreOrderItemId);
            return View(productionPlanQuangNd);
        }

        // POST: ProductionPlanQuangNds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductionPlanQuangNd productionPlanQuangNd)
        {
            //if (id != productionPlanQuangNd.PlanId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _productPlanQuangNDService.UpdateAsync(productionPlanQuangNd);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            var StoreOrderItemQuangNds = await _storeOrderItemQuangNDService.GetAllAsync();
            // ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName", productionPlanQuangNd.KitchenId);
            ViewData["StoreOrderItemId"] = new SelectList(StoreOrderItemQuangNds, "OrderItemId", "OrderItemId", productionPlanQuangNd.StoreOrderItemId);
            return View(productionPlanQuangNd);
        }

        // GET: ProductionPlanQuangNds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionPlanQuangNd = await _productPlanQuangNDService.GetByIdAysnc(id.Value);
            if (productionPlanQuangNd == null)
            {
                return NotFound();
            }

            return View(productionPlanQuangNd);
        }

        // POST: ProductionPlanQuangNds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productPlanQuangNDService.DeleteAsync(id);
            if(result == false)
            {
                return RedirectToAction(nameof(Delete), new { id = id });   
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductionPlanQuangNdExists(int id)
        //{
        //    return _context.ProductionPlanQuangNds.Any(e => e.PlanId == id);
        //}
    }
}
