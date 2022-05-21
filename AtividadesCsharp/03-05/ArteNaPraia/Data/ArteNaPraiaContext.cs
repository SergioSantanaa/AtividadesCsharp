using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArteNaPraia.obj.Debug;

    public class ArteNaPraiaContext : DbContext
    {
        public ArteNaPraiaContext (DbContextOptions<ArteNaPraiaContext> options)
            : base(options)
        {
        }

        public DbSet<ArteNaPraia.obj.Debug.Arte> Arte { get; set; }
    }
