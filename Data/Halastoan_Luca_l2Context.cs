using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Halastoan_Luca_l2.Models;

namespace Halastoan_Luca_l2.Data
{
    public class Halastoan_Luca_l2Context : DbContext
    {
        public Halastoan_Luca_l2Context(DbContextOptions<Halastoan_Luca_l2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Halastoan_Luca_l2.Models.Category> Category { get; set; } = default!;
    }
}