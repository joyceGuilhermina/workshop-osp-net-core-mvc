using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebMvc.Data;
using ProjetoWebMvc.Models;

namespace ProjetoWebMvc.Services
{
    public class SellerService
    {
        private readonly ProjetoWebMvcContext _context;

        public SellerService(ProjetoWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

    }
}
