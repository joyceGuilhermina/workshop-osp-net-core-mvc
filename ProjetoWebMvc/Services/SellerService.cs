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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        } 
    }
}
