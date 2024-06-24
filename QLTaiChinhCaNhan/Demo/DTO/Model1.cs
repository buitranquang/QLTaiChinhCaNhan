using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DTO
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model16")
        {
        }

        public virtual DbSet<ChiTieu> ChiTieu { get; set; }
        public virtual DbSet<KhoanVay> KhoanVay { get; set; }
        public virtual DbSet<LoaiCT> LoaiCT { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<Vi> Vi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTieu>()
                .HasOptional(e => e.ChiTieu1)
                .WithRequired(e => e.ChiTieu2);

            modelBuilder.Entity<LoaiCT>()
                .HasOptional(e => e.LoaiCT1)
                .WithRequired(e => e.LoaiCT2);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.ThanhPho)
                .IsFixedLength();
        }
    }
}
