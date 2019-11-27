using Mfm.Rms.Data.Contracts;
using Mfm.Rms.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mfm.Rms.Data.Services
{
    public class RmsTrainingDbContext : DbContext, IRmsTrainingDbContext
    {
        public RmsTrainingDbContext(DbContextOptions<RmsTrainingDbContext> options) : base(options){}

        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }

        public DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Training>().ToTable("Training");
        }
    }
}

