using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo")
                .HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .HasMaxLength(256)
                .HasColumnType("nvarchar");

            builder.Property(product => product.Description)
                .HasMaxLength(1024)
                .HasColumnType("nvarchar");

            builder.HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
