using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WShopping.Catalogo.Domain;

namespace WShopping.Catalogo.Infra.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(x => x.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(d => d.Dimensoes, x =>
            {
                x.Property(c => c.Altura)
                    .HasColumnName("Altura");

                x.Property(c => c.Largura)
                    .HasColumnName("Largura");

                x.Property(c => c.Profundidade)
                    .HasColumnName("Profundidade");
            });

            builder.ToTable("Produtos");
        }
    }
}
