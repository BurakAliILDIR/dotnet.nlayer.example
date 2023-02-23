using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seed
{
    internal class ProductFeatureSeeder : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {

            builder.HasData(new List<ProductFeature>()
            {
                new() { Id = 1, Color = "Kırmızı", Height = 40, Width = 2, ProductId = 3 },
                new() { Id = 2, Color = "Yeşil", Height = 30, Width = 5, ProductId = 2 },
                new() { Id = 3, Color = "Sarı", Height = 20, Width = 1, ProductId = 1 },
                new() { Id = 4, Color = "Kırmızı", Height = 30, Width = 73, ProductId = 4 },
                new() { Id = 5, Color = "Mavi", Height = 50, Width = 55, ProductId = 5 },
            });
        }
    }
}
