using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solucion.Model;

namespace Solucion.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Solucion.Model.Tarjeta> Tarjeta { get; set; }
        public DbSet<Solucion.Model.Balance> Balance { get; set; }
        public DbSet<Solucion.Model.Retiro> Retiro { get; set; }
    }
}
