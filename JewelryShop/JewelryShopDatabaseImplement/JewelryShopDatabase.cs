using Microsoft.EntityFrameworkCore;
using JewelryShopDatabaseImplement.Models;

namespace JewelryShopDatabaseImplement
{
    public class JewelryShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=MAKSIM\MSSQLSERVER01;Initial Catalog=JewelryShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Jewelry> Jewelrys { set; get; }

        public virtual DbSet<JewelryComponent> JewelryComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Client> Clients { set; get; }
    }
}
