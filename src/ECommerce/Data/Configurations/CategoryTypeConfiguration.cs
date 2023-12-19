using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "dbo")
                .HasKey(category => category.Id);

            builder.Property(product => product.Name)
                .HasMaxLength(256)
                .HasColumnType("nvarchar");
        }
    }
}
