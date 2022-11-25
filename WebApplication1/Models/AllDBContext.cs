using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class AllDBContext : DbContext
    {
        public AllDBContext(DbContextOptions<AllDBContext> options) : base(options)
        {

            //  Database.EnsureCreated();     // creating new db when first call

        }
    public DbSet<Movie> Movies { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
