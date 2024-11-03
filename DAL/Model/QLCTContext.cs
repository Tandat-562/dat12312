using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class QLCTContext : DbContext
    {
        public QLCTContext()
            : base("name=QLCTContext")
        {
        }

        public virtual DbSet<ChiTieu> ChiTieu { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<ThuNhap> ThuNhap { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTieu>()
                .HasRequired(c => c.Users) // Cần một User cho ChiTieu
        .WithMany(u => u.ChiTieu) // Một User có nhiều ChiTieu
        .HasForeignKey(c => c.UserId);



            modelBuilder.Entity<Users>()
                .HasMany(e => e.ThuNhap)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }

    }
}
