using LoremIpsum.Data.Entities;
using LoremIpsum.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Data.Context
{
    public class LoremIpsumContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        public LoremIpsumContext(DbContextOptions<LoremIpsumContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Endereco>(new EnderecoMap().Configure);
        }
    }
}
