using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.Reflection.Metadata;

namespace Infrastructure.Data
{
    public class TvMazeContext : DbContext
    {
        public TvMazeContext(DbContextOptions<TvMazeContext> options) : base(options) { }

        public DbSet<Show> Shows { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<WebChannel> WebChannels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Show>()
                .Property(s => s.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<Network>()
                .Property(n => n.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<WebChannel>()
                .Property(w => w.Id)
                .ValueGeneratedNever();

        }
    }
}
