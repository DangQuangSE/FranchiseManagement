using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FManagement.Entities.QuangND.Entities;
using FManagement.Services.QuangND;

namespace FManagement.RazorWepApp.QuangND.Pages.ProductionPlanQuangNds
{
    
    public class CreateModel : PageModel
    {

        private readonly IProductPlanQuangNDService _productPlanQuangNDService;
        private readonly StoreOrderItemQuangNDService _storeOrderItemQuangNDService;
        public CreateModel(IProductPlanQuangNDService productionPlanSV, StoreOrderItemQuangNDService storeOrderSV)
        {
            _productPlanQuangNDService = productionPlanSV;
            _storeOrderItemQuangNDService = storeOrderSV;
        }


        public IActionResult OnGet()
        {
            var StoreOrderItemQuangNds = _storeOrderItemQuangNDService.GetAllAsync().Result;
            //ViewData["KitchenId"] = new SelectList(_context.CentralKitchens, "KitchenId", "KitchenName");
            ViewData["StoreOrderItemId"] = new SelectList(StoreOrderItemQuangNds, "OrderItemId", "OrderItemId");
            return Page();
        }

        [BindProperty]
        public ProductionPlanQuangNd ProductionPlanQuangNd { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var resullt = await _productPlanQuangNDService.CreateAsync(ProductionPlanQuangNd);
            if (resullt > 0)
            {
                return RedirectToPage("./Index");

            }
            else
            {
                return Page();
            }

        }
    }
}
