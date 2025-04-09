using IMS_Gadget.ServerModel;
using Microsoft.EntityFrameworkCore;

namespace IMS_Gadget.DalLayer.DbContexts
{
    public class IMSGadgetDB : DbContext
    {
        public IMSGadgetDB(DbContextOptions<IMSGadgetDB> options) : base(options)
        {

        }
        public void BeginTransaction(short CommandTimeout = 180)
        {
            base.Database.SetCommandTimeout(CommandTimeout);
            base.Database.BeginTransaction();
        }

        public void CommitTransaction(short CommandTimeout = 180)
        {
            base.Database.SetCommandTimeout(CommandTimeout);
            base.Database.CommitTransaction();
        }

        public void RollBackTransaction(short CommandTimeout = 180)
        {
            base.Database.SetCommandTimeout(CommandTimeout);
            base.Database.RollbackTransaction();
        }

        public DbSet<GadgetsServerModel> GadgetsModel { get; set; }

        public DbSet<UsersServerModel> UsersModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GadgetsServerModel>().ToTable("Gadgets");
            modelBuilder.Entity<UsersServerModel>().ToTable("Users");
        }
    }
}
