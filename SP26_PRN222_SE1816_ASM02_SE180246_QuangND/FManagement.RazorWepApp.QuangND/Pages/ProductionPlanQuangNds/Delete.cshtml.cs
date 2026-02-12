using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FManagement.Entities.QuangND.Entities;
using FManagement.Services.QuangND;
using Microsoft.AspNetCore.SignalR;
using FManagement.RazorWepApp.QuangND.Hubs;

namespace FManagement.RazorWepApp.QuangND.Pages.ProductionPlanQuangNds
{
    public class DeleteModel : PageModel
    {
        private readonly IProductPlanQuangNDService _productPlanQuangNDService;
        private readonly IHubContext<ProductionPlanHub> _hubContext;

        public DeleteModel(IProductPlanQuangNDService productionPlanSV, IHubContext<ProductionPlanHub> hubContext)
        {
            _productPlanQuangNDService = productionPlanSV;
            _hubContext = hubContext;
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
            else
            {
                ProductionPlanQuangNd = productionplanquangnd;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _productPlanQuangNDService.DeleteAsync(id.Value);
            if (result)
            {
                await _hubContext.Clients.All.SendAsync("ProductionPlanDeleted", id.Value);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
