using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projetoempresa.Models;

    public class ProjetoEmpresaContext : DbContext
    {
        public ProjetoEmpresaContext (DbContextOptions<ProjetoEmpresaContext> options)
            : base(options)
        {
        }

        public DbSet<Projetoempresa.Models.Funcionario> Funcionario { get; set; }
    }
