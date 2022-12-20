namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
       /// <summary>
       /// tables
       /// </summary>
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //composite key
            builder.Entity<SongPerformer>()
                .HasKey(sngperf => new
                {
                    sngperf.SongId,
                    sngperf.PerformerId
                });
        }
    }
}
