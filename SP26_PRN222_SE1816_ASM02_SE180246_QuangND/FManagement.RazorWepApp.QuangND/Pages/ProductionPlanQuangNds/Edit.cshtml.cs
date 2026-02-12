using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FManagement.Entities.QuangND.Entities;
using FManagement.Services.QuangND;

namespace FManagement.RazorWepApp.QuangND.Pages.ProductionPlanQuangNds
{
    public class EditModel : PageModel
    {
        private readonly IProductPlanQuangNDService _productPlanQuangNDService;
        private readonly StoreOrderItemQuangNDService _storeOrderItemQuangNDService;

        public EditModel(IProductPlanQuangNDService productionPlanSV, StoreOrderItemQuangNDService storeOrderSV)
        {
            _productPlanQuangNDService = productionPlanSV;
            _storeOrderItemQuangNDService = storeOrderSV;
        }

        [BindProperty]
        public ProductionPlanQuangNd ProductionPlanQuangNd { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionplanquangnd = await _productPlanQuangNDService.GetByIdAysnc(id.Value); 
            if (productionplanquangnd == null)
            {
                return NotFound();
            }
            ProductionPlanQuangNd = productionplanquangnd;
            //ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName");
            var StoreOrderItemQuangNds = await _storeOrderItemQuangNDService.GetAllAsync();
            ViewData["StoreOrderItemId"] = new SelectList(StoreOrderItemQuangNds, "OrderItemId", "OrderItemId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _productPlanQuangNDService.UpdateAsync(ProductionPlanQuangNd);
            if (result > 0)
            {
                return RedirectToPage("./Index");

            }
            return Page();

        }
    }
}
