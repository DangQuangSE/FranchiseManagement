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
        /*

        // GET: ProductionPlanQuangNds/Create
        public IActionResult Create()
        {
            ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName");
            ViewData["StoreOrderItemId"] = new SelectList(_context.StoreOrderItemQuangNds, "OrderItemId", "OrderItemId");
            return View();
        }

        // POST: ProductionPlanQuangNds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanId,StoreOrderItemId,KitchenId,PlanDate,StartTime,EndTime,PlanStatus,PriorityLevel,TotalExpectedQuantity,ActualProducedQuantity,BatchNotes,LastModifiedBy,IsDeleted")] ProductionPlanQuangNd productionPlanQuangNd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionPlanQuangNd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName", productionPlanQuangNd.KitchenId);
            ViewData["StoreOrderItemId"] = new SelectList(_context.StoreOrderItemQuangNds, "OrderItemId", "OrderItemId", productionPlanQuangNd.StoreOrderItemId);
            return View(productionPlanQuangNd);
        }

        // GET: ProductionPlanQuangNds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionPlanQuangNd = await _context.ProductionPlanQuangNds.FindAsync(id);
            if (productionPlanQuangNd == null)
            {
                return NotFound();
            }
            ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName", productionPlanQuangNd.KitchenId);
            ViewData["StoreOrderItemId"] = new SelectList(_context.StoreOrderItemQuangNds, "OrderItemId", "OrderItemId", productionPlanQuangNd.StoreOrderItemId);
            return View(productionPlanQuangNd);
        }

        // POST: ProductionPlanQuangNds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanId,StoreOrderItemId,KitchenId,PlanDate,StartTime,EndTime,PlanStatus,PriorityLevel,TotalExpectedQuantity,ActualProducedQuantity,BatchNotes,LastModifiedBy,IsDeleted")] ProductionPlanQuangNd productionPlanQuangNd)
        {
            if (id != productionPlanQuangNd.PlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionPlanQuangNd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionPlanQuangNdExists(productionPlanQuangNd.PlanId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName", productionPlanQuangNd.KitchenId);
            ViewData["StoreOrderItemId"] = new SelectList(_context.StoreOrderItemQuangNds, "OrderItemId", "OrderItemId", productionPlanQuangNd.StoreOrderItemId);
            return View(productionPlanQuangNd);
        }

        // GET: ProductionPlanQuangNds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionPlanQuangNd = await _context.ProductionPlanQuangNds
                .Include(p => p.Kitchen)
                .Include(p => p.StoreOrderItem)
                .FirstOrDefaultAsync(m => m.PlanId == id);
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
            var productionPlanQuangNd = await _context.ProductionPlanQuangNds.FindAsync(id);
            if (productionPlanQuangNd != null)
            {
                _context.ProductionPlanQuangNds.Remove(productionPlanQuangNd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionPlanQuangNdExists(int id)
        {
            return _context.ProductionPlanQuangNds.Any(e => e.PlanId == id);
        }*/
    }
}
