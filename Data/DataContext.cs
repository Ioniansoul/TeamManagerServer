namespace TeamManagerServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {     
            
        }

        public DbSet<Player> Players => Set<Player>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(g => g.Cost)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Contribution)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<TeamPlayer>()
                .HasKey(pt => new { pt.PlayerId, pt.TeamId });
        }
    }
}
