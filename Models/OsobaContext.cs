using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspMvcCodeFirst1.Models
{
    public class OsobaContext : DbContext
    {
        public OsobaContext(DbContextOptions<OsobaContext> opcije) : base (opcije)
            {

            }
        public DbSet<Osoba> Osobe { get; set; }
    }
}
