using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FManagement.Entities.QuangND.Entities;
using FManagement.Services.QuangND;

namespace FManagement.RazorWepApp.QuangND.Pages.ProductionPlanQuangNds
{
    public class DetailsModel : PageModel
    {
        private readonly IProductPlanQuangNDService _productPlanQuangNDService;
        public DetailsModel(IProductPlanQuangNDService productionService) => _productPlanQuangNDService = productionService; 

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
            else
            {
                ProductionPlanQuangNd = productionplanquangnd;
            }
            return Page();
        }
    }
}
