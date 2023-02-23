using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NLayer.Repository.Seed
{
    internal class ProductSeeder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new List<Product>
            {
                new() { Id = 1, Name = "Sarı Kalem", CategoryId = 1, Price = 10, Stock = 5, CreatedAt = DateTime.Now },
                new()
                {
                    Id = 2, Name = "Yeşil Kalem", CategoryId = 1, Price = 15, Stock = 15, CreatedAt = DateTime.Now
                },
                new()
                {
                    Id = 3, Name = "Kırmızı Kalem", CategoryId = 1, Price = 5, Stock = 3, CreatedAt = DateTime.Now
                },
                new()
                {
                    Id = 4, Name = "Kırmızı Defter", CategoryId = 2, Price = 8, Stock = 13, CreatedAt = DateTime.Now
                },
                new()
                {
                    Id = 5, Name = "Mavi Defter", CategoryId = 2, Price = 2, Stock = 100, CreatedAt = DateTime.Now
                },
            });
        }
    }
}