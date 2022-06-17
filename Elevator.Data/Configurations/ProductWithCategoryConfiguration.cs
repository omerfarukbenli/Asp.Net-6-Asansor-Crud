using Elevator.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Data.Configurations
{
    public class ProductWithCategoryConfiguration : IEntityTypeConfiguration<ProductWithCategory>
    {
        public void Configure(EntityTypeBuilder<ProductWithCategory> builder)
        {
            builder.HasKey(a => new { a.CategoryID, a.ProductID });
            builder.HasOne(pt => pt.Category).WithMany(p => p.ProductWithCategories).HasForeignKey(pt => pt.CategoryID);
            builder.HasOne(pt => pt.Product).WithMany(t => t.ProductWithCategories).HasForeignKey(pt => pt.ProductID);
        }
    }
}
