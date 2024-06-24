namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiCT")]
    public partial class LoaiCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiCT()
        {
            ChiTieu = new HashSet<ChiTieu>();
        }

        [Key]
        [StringLength(50)]
        public string MaLoaiCT { get; set; }

        [StringLength(50)]
        public string TenLoaiCT { get; set; }

        [StringLength(50)]
        public string MaTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTieu> ChiTieu { get; set; }

        public virtual LoaiCT LoaiCT1 { get; set; }

        public virtual LoaiCT LoaiCT2 { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
