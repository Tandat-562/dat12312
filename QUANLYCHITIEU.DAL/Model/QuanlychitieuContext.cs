using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QUANLYCHITIEU.DAL.Model
{
    public partial class QuanlychitieuContext : DbContext
    {
        public QuanlychitieuContext()
            : base("name=QuanlychitieuContext")
        {
        }

        public virtual DbSet<Chitieu> Chitieu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitieu>()
                .Property(e => e.SoTien)
                .HasPrecision(18, 0);
        }
    }
}
