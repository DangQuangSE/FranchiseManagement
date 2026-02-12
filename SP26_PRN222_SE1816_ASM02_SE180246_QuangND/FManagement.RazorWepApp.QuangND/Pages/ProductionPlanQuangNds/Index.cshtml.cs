using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FManagement.Entities.QuangND.Entities;
using FManagement.Services.QuangND;
using Microsoft.AspNetCore.Authorization;

namespace FManagement.RazorWepApp.QuangND.Pages.ProductionPlanQuangNds
{
    [Authorize(Roles = "1,2")]
    public class IndexModel : PageModel
    {
        private readonly IProductPlanQuangNDService _productPlanQuangNDService;

        public IndexModel(IProductPlanQuangNDService productPlanQuangNDService)

         => _productPlanQuangNDService = productPlanQuangNDService;


        public IList<ProductionPlanQuangNd> ProductionPlanQuangNd { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ProductionPlanQuangNd = await _productPlanQuangNDService.GetAllAsync();
        }
    }
}
