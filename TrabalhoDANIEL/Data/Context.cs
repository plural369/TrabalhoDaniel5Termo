using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoDANIEL.Models;

namespace TrabalhoDANIEL.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Produto> produto { get; set; }

        public DbSet<Funcionario> funcianario { get; set; }
    }
}
