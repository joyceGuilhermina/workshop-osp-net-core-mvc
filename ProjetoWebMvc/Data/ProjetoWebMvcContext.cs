using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoWebMvc.Models;

namespace ProjetoWebMvc.Data
{
    public class ProjetoWebMvcContext : DbContext
    {
        public ProjetoWebMvcContext (DbContextOptions<ProjetoWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoWebMvc.Models.Department> Department { get; set; }
    }
}
