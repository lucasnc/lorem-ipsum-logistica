using LoremIpsum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.TipoEndereco)
                .IsRequired();

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Localidade)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Uf)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(c => c.Complemento)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(c => c.Bairro)
                .IsRequired(false)
                .HasMaxLength(50);

        }
    }
}
