using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_DOS.Models;

namespace Projeto_DOS.Data
{
    public class Projeto_DOSContext : DbContext
    {
        public Projeto_DOSContext (DbContextOptions<Projeto_DOSContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto_DOS.Models.Cadalu> Cadalu { get; set; }
    }
}
