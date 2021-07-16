using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wardrobe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cloths> Cloths { get; set; }
        public DbSet<ClothGallery> ClothGallery { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Kind> Kind { get; set; }
    }
}

