using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArteNaPraia.Models;

    public class ArteNaPraiaContext : DbContext
    {
        public ArteNaPraiaContext (DbContextOptions<ArteNaPraiaContext> options)
            : base(options)
        {
        }

        public DbSet<ArteNaPraia.Models.Arte> Arte { get; set; }

        public DbSet<ArteNaPraia.Models.Artista> Artista { get; set; }
    }
