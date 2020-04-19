using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Data
{
    public class MorgenmadContext: DbContext
    {
        public MorgenmadContext(DbContextOptions<MorgenmadContext> options): base(options) { }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Buffet> Orders { get; set; }
    }
}
