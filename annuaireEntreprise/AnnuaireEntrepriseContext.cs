using annuaireEntreprise.DB.Model;
using Microsoft.EntityFrameworkCore;


namespace annuaireEntreprise
{
    class AnnuaireEntreriseContext : DbContext
    {

        #region Ctor

        public AnnuaireEntreriseContext() : base()
        {

        }
        #endregion

        #region DbSET
        public DbSet<Sites> Sites { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Employes> Employes { get; set; }
        #endregion

        #region Configuration

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(
               "Data Source=C:\\Users\\Lucile\\Documents\\CUBES INDIVIDUEL\\C#\\annuaireEntreprise\\annuaireEntreprise\\DB\\annuaireEntreprise.db");
            }

            base.OnConfiguring(optionsBuilder);
        }
        #endregion

        #region Seeder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sites>().HasKey(c => c.Id_site);
            modelBuilder.Entity<Sites>().Property(b => b.Id_site).ValueGeneratedOnAdd();

            modelBuilder.Entity<Services>().HasKey(c => c.Id_service);
            modelBuilder.Entity<Services>().Property(b => b.Id_service).ValueGeneratedOnAdd();

            modelBuilder.Entity<Employes>().HasKey(c => c.Id_employe);
            modelBuilder.Entity<Employes>().Property(b => b.Id_employe).ValueGeneratedOnAdd();

        }

            #endregion

        }
}
