using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebMvc.Data;
using ProjetoWebMvc.Models;
namespace ProjetoWebMvc.Services
{
    public class DepartmentService
    {
        private readonly ProjetoWebMvcContext _context;

        public DepartmentService(ProjetoWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(X => X.Name).ToList();
        }
    }
}
