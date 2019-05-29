using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using korean.Models;

namespace korean.Data
{
    public class ApplicationDbContext : IdentityDbContext<kruser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<korece> words { get; set; }
       
        public DbSet<comment> comments { get; set; }
    }
}
