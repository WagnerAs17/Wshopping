using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WShopping.Catalogo.Domain;

namespace WShopping.Catalogo.Infra.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            //1:N
            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);

            builder.ToTable("Categorias");
        }
    }
}
