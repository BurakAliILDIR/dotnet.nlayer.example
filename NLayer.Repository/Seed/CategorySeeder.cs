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
    internal class CategorySeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new List<Category>()
            {
                new() { Id = 1, Name = "Kalemler" },
                new() { Id = 2, Name = "Kitaplar" },
                new() { Id = 3, Name = "Defterler" },
            });
        }
    }
}