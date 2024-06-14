using LoremIpsum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoremIpsum.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.DataNascimento)
                .IsRequired();

            builder.Property(c => c.Genero)
                .IsRequired();

            builder.HasMany(c => c.Enderecos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);
        }
    }
}
