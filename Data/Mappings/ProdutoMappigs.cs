using Estocando.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estocando.Data.Mappings
{
    public class ProdutoMappings : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(t =>t.Id);

            builder.Property(t=> t.Nome)
            .IsRequired()
            .HasMaxLength(60);

            builder.Property(t => t.Quantidade)
            .IsRequired();

            builder.Property(t => t.Ativo)
            .IsRequired();
        }
    }
}