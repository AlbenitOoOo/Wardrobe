using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wardrobe.Models;

namespace Wardrobe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ClothImage> ClothImages { get; set; }
    }
}
