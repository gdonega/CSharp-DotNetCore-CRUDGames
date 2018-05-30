using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamecrud.Models;
using Microsoft.EntityFrameworkCore;

namespace gamecrud.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

    }
}
