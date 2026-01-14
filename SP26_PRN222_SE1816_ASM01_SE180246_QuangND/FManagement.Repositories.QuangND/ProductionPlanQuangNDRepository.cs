using FManagement.Entities.QuangND.Entities;
using FManagement.Repositories.QuangND.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FManagement.Repositories.QuangND
{
    public class ProductionPlanQuangNDRepository : GenericRepository<ProductionPlanQuangNd>
    {
        public ProductionPlanQuangNDRepository() { }
        public ProductionPlanQuangNDRepository(FranchiseManagementContext context) => _context = context;
        public async Task<List<ProductionPlanQuangNd>> GetAllAsync()
        {
            var items = await _context.ProductionPlanQuangNds
            .Include(p => p.Kitchen)
            .Include(p => p.StoreOrderItem)
            .Include(p => p.ProductBatches).ToListAsync();
            return items ?? new List<ProductionPlanQuangNd>();
        }
        public async Task<ProductionPlanQuangNd> GetByIdAysnc(int id)
        {
            var item = await _context.ProductionPlanQuangNds
            .Include(p => p.Kitchen)
            .Include(p => p.StoreOrderItem)
            .Include(p => p.ProductBatches)
            .FirstOrDefaultAsync(p => p.PlanId == id);
            return item ?? new ProductionPlanQuangNd();
        }
        public async Task<List<ProductionPlanQuangNd>> SearchAsync(int id, int quantityOrdered, string PlanStatus) //chose 2 attribute from main table, 1 from foreign table
        {
            var items = await _context.ProductionPlanQuangNds.Include(p => p.Kitchen)
            .Include(p => p.StoreOrderItem)
            .Include(p => p.ProductBatches).
            Where(c =>
            ((c.PlanId == id || id == null || id == 0) &&
            (c.StoreOrderItem.QuantityOrdered == quantityOrdered || quantityOrdered == null || quantityOrdered == 0) &&
            (c.PlanStatus.Contains(PlanStatus) || string.IsNullOrEmpty(PlanStatus))))
            .ToListAsync();
            return items;
        }
    }
}
