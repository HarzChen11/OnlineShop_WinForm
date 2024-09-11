using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Models.Entities
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Deliver> Deliver { get; set; }
<<<<<<< HEAD
        public virtual DbSet<Logistics> Logistics { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<PointsSystem> PointsSystem { get; set; }
=======
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Trolley> Trolley { get; set; }
        public virtual DbSet<TrolleyDetails> TrolleyDetails { get; set; }
        public virtual DbSet<ProductImg> ProductImg { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
<<<<<<< HEAD
=======
                .HasMany(e => e.Order)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
                .HasMany(e => e.Trolley)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deliver>()
                .HasMany(e => e.Order)
<<<<<<< HEAD
                .WithOptional(e => e.Deliver1)
                .HasForeignKey(e => e.Deliver);

            modelBuilder.Entity<Logistics>()
                .Property(e => e.TempLogisticsID)
                .IsFixedLength();

            modelBuilder.Entity<Logistics>()
                .Property(e => e.ReceiverAddress)
=======
                .WithRequired(e => e.Deliver1)
                .HasForeignKey(e => e.Deliver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderNumber)
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
<<<<<<< HEAD
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PointsSystem>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<PointsSystem>()
                .Property(e => e.CreatDate)
                .IsFixedLength();

=======
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            modelBuilder.Entity<Product>()
                .Property(e => e.ProductImg)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductImg1)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductImgID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.TrolleyDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.ProductType1)
                .HasForeignKey(e => e.ProductType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trolley>()
                .HasMany(e => e.TrolleyDetails)
                .WithRequired(e => e.Trolley)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductImg>()
                .Property(e => e.ProductImg1)
                .IsUnicode(false);
        }
    }
}
