using Microsoft.EntityFrameworkCore;
using ProjetoWebMvc.Data;
using ProjetoWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly ProjetoWebMvcContext _context;

        public SalesRecordService(ProjetoWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAaync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.salesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(X => X.Seller.Department)
                .OrderByDescending(X => X.Date)
                .ToListAsync();
        }
    }
}
