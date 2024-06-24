namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            ChiTieu = new HashSet<ChiTieu>();
            KhoanVay = new HashSet<KhoanVay>();
            LoaiCT = new HashSet<LoaiCT>();
            Vi = new HashSet<Vi>();
        }

        [Key]
        [StringLength(50)]
        public string MaTK { get; set; }

        [Required]
        [StringLength(30)]
        public string TenTK { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string ThanhPho { get; set; }

        public long? SDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTK { get; set; }

        public int? SLVi { get; set; }

        [StringLength(30)]
        public string TenUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTieu> ChiTieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoanVay> KhoanVay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiCT> LoaiCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vi> Vi { get; set; }
    }
}
